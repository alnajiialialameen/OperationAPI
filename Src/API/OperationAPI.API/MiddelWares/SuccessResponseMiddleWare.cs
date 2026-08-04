using System.Text.Json;
using System.Text;
using OperationAPI.API.Models;
using OperationAPI.Application.Exceptions;

namespace OperationAPI.API.MiddelWares
{
    public class SuccessResponseMiddleWare
    {
        private readonly RequestDelegate _next;

        public SuccessResponseMiddleWare(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            //if(context.Request.Method == "OPTIONS")
            //{
            //    context.Response.StatusCode = StatusCodes.Status200OK;

            //    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //    context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
            //    context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");

            //    await context.Response.CompleteAsync();
            //    return;
            //}
            // لان ال MW قد تنقل ال Response لاي MW اخر
            // عشان كده لمن اوصل هنا لازم احافظ علي البيانات القديمة عندي
            // وهنا حفظت ال بيانات القديمة او ال Response الناتج من ال MW السابقة في المتغير ده
            var originalBodyStream = context.Response.Body;

            // انشئ استريم جديد
            using var memoryStream = new MemoryStream();
            // خلي اي MW كتب Response يحفظها لي في ال memoryStream دي
            // بي كده انا شلت البيانات القديمة وخليت البيانات الجديدة تتحفظ لي في memoryStream خاص بي
            context.Response.Body = memoryStream;

            try
            {
                // انقل التنفيذ الي ال MW التالي
                await _next(context);

                // اختبر هل نجحت العملية ام لا لانه لو نجحت ح اعدل حسب ما انا عاوز غير كده ما ح اعدل
                if (context.Response.StatusCode >= 200 && context.Response.StatusCode < 300
                    && context.Response.ContentType != null
                    && context.Response.ContentType.Contains("application/json", StringComparison.OrdinalIgnoreCase)
                    )
                {
                    // الدالة سيك هي دالة بتنقل المؤشر الي موقع محدد
                    // لمن اكتب اي حاجة في ال ميموري استريم المؤشر بكون قاعد في النهاية
                    // ولو بديت اقرا طوالي بدون ما انقل المؤشر
                    // للنهاية ف ده بيعني اني ما ح اقرا حاجه لانه المؤشر قاعد في النهاية خالص
                    // ف عشان انقل المؤشر الي البداية واقرا منه كل البيانات ح استخدم الدالة سيك
                    // الدالة سيك بتتقبلمعاملين الاول اتحرك كم خانه والتاني ابدا من وين
                    // يعني اتحرك 0 خانه او بمعني اخر ما تتحرك 
                    // التاني ابدا التحرك من وين وهنا قلنا ليهو من البداية 
                    // يعني من بداية ال ستريم اتحرك 0 خانه وده بينقل لي المؤشر لي بداية الاستريم
                    memoryStream.Seek(0, SeekOrigin.Begin); // دي الدالة سيك ال بنتحدث عنها

                    // بعد ما نقلت المؤشر للبداية ح ابدا اقرا في البيانات الموجودة في الاستريم
                    var body = await new StreamReader(memoryStream).ReadToEndAsync();

                    // الغرض من الكلاس ده انه اغلف النتيجة حقتي عشان تكون النتائج بي شكل محدد
                    // ف هنا بختبر هل اصلا النتيجة جاية بالشكل ال انا عاوزه(مغلف) ولا لا (ما مغلف) ده الشرط كده
                    // لو الرد مش مغلف أصلاً
                    if (!body.TrimStart().StartsWith("{\"status\"", StringComparison.OrdinalIgnoreCase)) // هنا الشرط حسب شكل الاوبجكت حقي
                    {
                        // هنا ح نغلف الاستريم
                        var apiResponse = new ResponseDTO<object>
                        {
                            status = "Success",
                            message = context.Items["success_message"]?.ToString() ?? "Request Processed Successfully",
                            // هنا حولنا الناتج من string الي JSON 
                            data = JsonSerializer.Deserialize<object>(body,
                                new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                })
                        };

                        // هنا حولنا من اوبجكت الي string عشان احفظه في الاستريم تاني
                        var jsonResponse = JsonSerializer.Serialize(apiResponse);
                        var responseBytes = Encoding.UTF8.GetBytes(jsonResponse);

                        // هنا رجعنا الاستريم الاصلي لي محله
                        context.Response.Body = originalBodyStream;
                        //  نعدل نوع المحتوي وباقي التفاصيل
                        context.Response.ContentType = "application/json";
                        context.Response.ContentLength = responseBytes.Length;
                        // هنا ضفنا الاستريم ال انا انشاته لي ال بودي
                        await context.Response.Body.WriteAsync(responseBytes, 0, responseBytes.Length);

                        return;
                    }
                }

                // لو ما محتاج تغليف
                memoryStream.Seek(0, SeekOrigin.Begin); // حرك المؤشر لي بداية الاستريم عشان ح بادا اقرا
                await memoryStream.CopyToAsync(originalBodyStream); // انسخ محتوي الاستريم الي الاستريم الاصلي
            }
            catch (Exception ex)
            {
                context.Response.Body = originalBodyStream;
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                ResponseDTO<string> errorResponse;

                if (ex is BadRequestException badRequest)
                {
                    context.Response.StatusCode = 400;

                    // استخراج كل الرسائل
                    var allErrors = string.Join(", ",
                        badRequest.ValidationErrors.SelectMany(x => x.Value));

                    errorResponse = new ResponseDTO<string>
                    {
                        status = "Error",
                        message = $"Middleware Exception: {badRequest.Message} {allErrors}",
                        data = null
                    };
                }
                else
                {
                    context.Response.StatusCode = 500;

                    errorResponse = new ResponseDTO<string>
                    {
                        status = "Error",
                        message = "Middleware Exception: " + ex.Message,
                        data = null
                    };
                }

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
            finally
            {
                // في النهاية خلي البودي يرجع يشيل الاستريم الاصلي حقه
                context.Response.Body = originalBodyStream;
            }
        }

    }


}
