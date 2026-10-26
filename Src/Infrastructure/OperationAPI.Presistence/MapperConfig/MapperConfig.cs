using AutoMapper;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.MapperConfig
{
  public  class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AircraftSizeDomain, AircraftSize>().ReverseMap();

            CreateMap<WorkOn, WorkOnDomain>().ReverseMap();
            CreateMap<CompanyInfo, CompanyInfoDomain>().ReverseMap();
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();
            CreateMap<FuelCompanyDomain, FuelCompany>().ReverseMap();

            CreateMap<CountryDomain, Country>().ReverseMap();
           
            CreateMap<HandlingAgentsCompanyDomain, HandlingAgentsCompany>().ReverseMap();

            ///عند الإضافة (Domain → Entity) يتم تجاهل Size
            CreateMap<AircraftTypeDomain, AircraftType>().ForMember(dest => dest.Size, opt => opt.Ignore());
            CreateMap<AircraftType, AircraftTypeDomain>();


            ///AircraftRegistration
            ///عند الإضافة (Domain → Entity) يتم تجاهل AircraftType ,AireLine
            ///put / post

            CreateMap<AircraftRegistrationDomain, AircraftRegistration>()
                .ForMember(dest => dest.AircraftType, opt => opt.Ignore());
            //.ForMember(dest => dest.AireLine, opt => opt.Ignore());

            CreateMap<AircraftRegistration, AircraftRegistrationView>();


            // Get
            CreateMap<AircraftRegistration, AircraftRegistrationDomain>()
                .ForMember(dest => dest.AircraftType, opt => opt.MapFrom(src => src.AircraftType));
            //.ForMember(dest => dest.AireLine, opt => opt.MapFrom(src => src.AireLine));

            // AirLine
            CreateMap<AirLine, AirLineDomain>()
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.ArName))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

            // AirPort
            CreateMap<AirPort, AirPortDomain>()
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country!.NameEn?? src.Country.NameAr))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();


            //AirLineAgent
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();
            /// put / post
            CreateMap<AirLineAgentDomain, AirLineAgent>()
               .ForMember(dest => dest.AirLine, opt => opt.Ignore());

            // get
            CreateMap<AirLineAgent, AirLineAgentDomain>()
              .ForMember(dest => dest.AirLineCode, opt => opt.MapFrom(src => src.AirLine!.Code))
              .ForMember(dest => dest.AirLineNameEn, opt => opt.MapFrom(src => src.AirLine!.Name))
              .ForMember(dest => dest.AirLineNameAr, opt => opt.MapFrom(src => src.AirLine!.ArName));

            //CreateMap<TowerDatum, TowerDataDomain>().ReverseMap();
            //--------------------------------------------------------------------------
            CreateMap<TowerDatum, TowerDataDomain>()
     // 1. فحص هل يوجد أي طلب حالته 2
     .ForMember(dest => dest.IsAnyRequestNotAccepted, opt => opt.MapFrom(src =>
         src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.RequestStatus == 1)))

     // 2. فحص هل يوجد أي طلب حالته 3
     .ForMember(dest => dest.IsAnyRequestNotConfirm, opt => opt.MapFrom(src =>
         src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.RequestStatus == 2)))

     // 3. جلب أكبر حالة موجودة للرحلة (3 ثم 2 ثم 1، أو 0 عند عدم وجود طلبات)
     .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src =>
         src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Max(d => (int?)d.RequestStatus) ?? 0
     ));

            // للإبقاء على إمكانية التحويل العكسي عند الحفظ في CreateAsync
            CreateMap<TowerDataDomain, TowerDatum>();
            //-----------------------------------------------------------------

            CreateMap<OfficerDatum, OfficerDataDomain>().ReverseMap();

            #region flight  Mapper



            //    CreateMap<TowerDatum, TowerDataViewDomain>()
            //.ForMember(dest => dest.Registration, opt => opt.MapFrom(src => src.AircraftReg.Registration))
            //.ForMember(dest => dest.AirportFromNameAr, opt => opt.MapFrom(src => src.AirportIdFromNavigation.NameAr))
            //.ForMember(dest => dest.AirportFromNameEn, opt => opt.MapFrom(src => src.AirportIdFromNavigation.NameEn))
            //.ForMember(dest => dest.AirportToNameAr, opt => opt.MapFrom(src => src.AirportIdToNavigation.NameAr))
            //.ForMember(dest => dest.AirportToNameEn, opt => opt.MapFrom(src => src.AirportIdToNavigation.NameEn))
            //.ForMember(dest => dest.AirLineNameEn, opt => opt.MapFrom(src => src.AirLine.Name))

            //// 1. جلب الـ OfficerDataId المرتبط بالرحلة
            //.ForMember(dest => dest.OfficerDataId, opt => opt.MapFrom(src =>
            //    src.OfficerData.Select(o => (int?)o.Id).FirstOrDefault()))

            //// 2. حساب RequestStatus (3 للتأكيد، 2 للقبول، 1 للطلب، و 0 في حال عدم وجود طلب)
            //.ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src =>
            //    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.ConfirmAgentBy != null) ? 3 :
            //    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.AcceptedBy != null) ? 2 :
            //    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.RequestedBy != null) ? 1 : 0
            //));



          
            CreateMap<ServiceRequestDetail, RequestDetailDomain>();

               //--- 2
            CreateMap<TowerDatum, TowerDataViewDomain>()
                .ForMember(dest => dest.Registration, opt => opt.MapFrom(src => src.AircraftReg.Registration))
                .ForMember(dest => dest.AirportFromNameAr, opt => opt.MapFrom(src => src.AirportIdFromNavigation.NameAr))
                .ForMember(dest => dest.AirportFromNameEn, opt => opt.MapFrom(src => src.AirportIdFromNavigation.NameEn))
                .ForMember(dest => dest.AirportToNameAr, opt => opt.MapFrom(src => src.AirportIdToNavigation.NameAr))
                .ForMember(dest => dest.AirportToNameEn, opt => opt.MapFrom(src => src.AirportIdToNavigation.NameEn))
                .ForMember(dest => dest.AirLineNameEn, opt => opt.MapFrom(src => src.AirLine.Name))

                // 1. جلب OfficerDataId
                .ForMember(dest => dest.OfficerDataId, opt => opt.MapFrom(src =>
                    src.OfficerData.Select(o => (int?)o.Id).FirstOrDefault()))

                // 2. إرجاع أكبر قيمة لـ RequestStatus (3 ثم 2 ثم 1، أو 0 إذا لم يوجد أي طلب)
                .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src =>
                    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Max(d => (int?)d.RequestStatus) ?? 0))

                // 3. هل يوجد أي طلب لم يُقبل بعد (RequestStatus == 1)
                .ForMember(dest => dest.IsAnyRequestNotAccepted, opt => opt.MapFrom(src =>
                    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.RequestStatus == 1)))

                // 4. هل يوجد أي طلب مقبول ولكن لم يُؤكد من الوكيل بعد (RequestStatus == 2)
                .ForMember(dest => dest.IsAnyRequestNotConfirm, opt => opt.MapFrom(src =>
                    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails).Any(d => d.RequestStatus == 2)))

                // 5. جلب قائمة بجميع تفاصيل الطلبات وحالاتها المختلفة المرتبطة بهذه الرحلة
                .ForMember(dest => dest.RequestDetails, opt => opt.MapFrom(src =>
                    src.ServiceRequests.SelectMany(sr => sr.ServiceRequestDetails)));




            // جلب الـ Id من جدول OfficerData المرتبط بالرحلة



            CreateMap<TowerDatum, TowerDataStartUpDomain>();



            #endregion


            CreateMap<ServiceType, ServiceTypeDomain>().ReverseMap();


            //CreateMap<ServiceRequestDetailDomain, ServiceRequest>()
            //    .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ServiceRequestDetailDomain, ServiceRequestDetail>()
         .ForMember(dest => dest.Id, opt => opt.Ignore())
         .ForMember(dest => dest.ServiceRequest, opt => opt.Ignore())
         // تجاهل أي حقل قيمته null في الـ model حتى لا يمسح القيم القديمة في قاعدة البيانات
         .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));


            ////----------------------------------------------------------
            CreateMap<ServiceRequestDetail, ServiceRequestDetailViewDomain>()
      // جلب اسم نوع الخدمة من جدول ServiceType (يمكنك استخدام NameAr أو NameEn حسب رغبتك)
      .ForMember(dest => dest.ServiceTypeName, opt => opt.MapFrom(src => src.ServiceType.NameAr))

      // جلب البيانات من جدول الأب ServiceRequest
      .ForMember(dest => dest.TowerDataId, opt => opt.MapFrom(src => src.ServiceRequest.TowerDataId))
      .ForMember(dest => dest.AirlineId, opt => opt.MapFrom(src => src.ServiceRequest.AirlineId))

      // جلب اسم شركة الطيران من جدول Airline المرتبط بـ ServiceRequest
      .ForMember(dest => dest.AirlineName, opt => opt.MapFrom(src => src.ServiceRequest.Airline.Name));



            ///----------------------------------------

            // التحويل من Entity إلى Domain (لإرجاع النتيجة بعد الحفظ)
            CreateMap<ServiceRequestDetail, ServiceRequestDetailDomain>()
                .ForMember(dest => dest.TowerDataId, opt => opt.MapFrom(src => src.ServiceRequest.TowerDataId))
                .ForMember(dest => dest.AirlineId, opt => opt.MapFrom(src => src.ServiceRequest.AirlineId));

        }



    }
    
}
