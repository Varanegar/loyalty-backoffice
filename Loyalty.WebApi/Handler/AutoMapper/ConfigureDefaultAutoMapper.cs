using Anatoli.DataAccess.Models;
using Anatoli.ViewModels.BaseModels;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.Order;
using Anatoli.ViewModels.PersonnelAcitvityModel;
using Anatoli.ViewModels.ProductModels;
using Anatoli.ViewModels.StockModels;
using Anatoli.ViewModels.StoreModels;
using AutoMapper;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loyalty.WebApi.Handler
{
    public static class ConfigDefaultAutoMapperHelper
    {
        public static void Config()
        {
            ConfigModelToViewModel();
            ConfigViewModelToModel();
        }
        private static void ConfigModelToViewModel()
        {
            Mapper.CreateMap<CityRegion, CityRegionViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.CityRegion2Id.ToString())).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseType, BaseTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseValue, BaseValueViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<ProductGroup, ProductGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ProductGroup2Id.ToString())).ForMember(p => p.ParentUniqueId, opt => opt.MapFrom(src => src.ProductGroup2Id)).ForMember(p => p.ID, opt => opt.Ignore());

            Mapper.CreateMap<CustomerShipAddress, CustomerShipAddressViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerTag, CustomerTagViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ParentId.ToString())).ForMember(p => p.ParentId, opt => opt.Ignore());
            Mapper.CreateMap<CustomerGroup, CustomerGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ParentId.ToString())).ForMember(p => p.ParentId, opt => opt.Ignore());


        }

        private static void ConfigViewModelToModel()
        {
            Mapper.CreateMap<CityRegionViewModel, CityRegion>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.CityRegion2Id, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString))).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseTypeViewModel, BaseType>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseValueViewModel, BaseValue>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<ProductGroupViewModel, ProductGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.ProductGroup2Id, opt => opt.MapFrom(src => ConvertNullableStringToGuid(src.ParentUniqueIdString))).ForMember(p => p.ProductGroup2Id, opt => opt.MapFrom(src => src.ParentUniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());

            Mapper.CreateMap<CustomerShipAddressViewModel, CustomerShipAddress>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerViewModel, Customer>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId));
            Mapper.CreateMap<CustomerTagViewModel, CustomerTag>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore()).ForMember(p => p.ParentId, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString)));
            Mapper.CreateMap<CustomerGroupViewModel, CustomerGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore()).ForMember(p => p.ParentId, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString)));

        }
        private static Guid? ConvertNullableStringToGuid(string data)
        {
            var guid = Guid.Empty;
            Guid.TryParse(data, out guid);
            return guid;
        }

    }
}