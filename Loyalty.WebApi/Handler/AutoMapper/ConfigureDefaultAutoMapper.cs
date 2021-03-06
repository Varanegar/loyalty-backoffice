﻿using Anatoli.DataAccess.Models;
using Anatoli.DataAccess.Models.Identity;
using Anatoli.ViewModels.BaseModels;
using Anatoli.ViewModels.CustomerModels;
using Anatoli.ViewModels.LoyaltyModels;
using Anatoli.ViewModels.Order;
using Anatoli.ViewModels.PersonnelAcitvityModel;
using Anatoli.ViewModels.ProductModels;
using Anatoli.ViewModels.StockModels;
using Anatoli.ViewModels.StoreModels;
using Anatoli.ViewModels.User;
using AutoMapper;
using Loyalty.DataAccess.Models;
using Loyalty.DataAccess.Models.Account;
using Loyalty.DataAccess.Models.Loyalty;
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
            Mapper.CreateMap<User, UserProfileModel>().ForMember(p => p.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber ?? "")).ForMember(p => p.FullName, op => op.MapFrom(src => src.FullName ?? ""));

            #region Base Data
            Mapper.CreateMap<CityRegion, CityRegionViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.CityRegion2Id.ToString())).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseType, BaseTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseValue, BaseValueViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            #endregion

            #region Product
            Mapper.CreateMap<Product, ProductViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<ProductGroup, ProductGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ProductGroup2Id.ToString())).ForMember(p => p.ParentUniqueId, opt => opt.MapFrom(src => src.ProductGroup2Id)).ForMember(p => p.ID, opt => opt.Ignore());
            #endregion

            #region Customer
            Mapper.CreateMap<CustomerShipAddress, CustomerShipAddressViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<Customer, CustomerViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.CustomerTypeName, opt => opt.MapFrom(src => src.CustomerType.CustomerTypeName))
                .ForMember(p => p.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName));
            Mapper.CreateMap<CustomerTag, CustomerTagViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ParentId.ToString())).ForMember(p => p.ParentId, opt => opt.Ignore());
            Mapper.CreateMap<CustomerGroup, CustomerGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ParentUniqueIdString, opt => opt.MapFrom(src => src.ParentId.ToString())).ForMember(p => p.ParentId, opt => opt.Ignore());
            Mapper.CreateMap<CustomerMonetaryHistory, CustomerMonetaryHistoryViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerNonMonetaryHistory, CustomerNonMonetaryHistoryViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerTransactionHistory, CustomerTransactionHistoryViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            #endregion

            #region Loyalty
            Mapper.CreateMap<LoyaltyCardSet, LoyaltyCardSetViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyCard, LoyaltyCardViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTier, LoyaltyTierViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<UserGroup, LoyaltyUserGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTrigger, LoyaltyTriggerViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTriggerType, LoyaltyTriggerTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyValueTypeAttribute, LoyaltyValueTypeAttributeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyProgramGroup, LoyaltyProgramGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleGroup, LoyaltyRuleGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyActionType, LoyaltyActionTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRule, LoyaltyRuleViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleType, LoyaltyRuleTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleTrigger, LoyaltyRuleTriggerViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.LoyaltyTriggerName, op => op.MapFrom(src => src.LoyaltyTrigger.LoyaltyTriggerName));
            Mapper.CreateMap<LoyaltyRuleAction, LoyaltyRuleActionViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.LoyaltyActionTypeName, op => op.MapFrom(src => src.LoyaltyActionType.LoyaltyActionTypeName)).ForMember(p => p.LoyaltyTierName, op => op.MapFrom(src => src.LoyaltyTier.TierName)).ForMember(p => p.LoyaltyValueTypeAttributeName, op => op.MapFrom(src => src.LoyaltyValueTypeAttribute.LoyaltyValueTypeAttributeName));
            Mapper.CreateMap<LoyaltyRuleCondition, LoyaltyRuleConditionViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleConditionProduct, LoyaltyRuleConditionProductViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ProductName, op => op.MapFrom(src => src.Product.ProductName));
            Mapper.CreateMap<LoyaltyRuleConditionProductGroup, LoyaltyRuleConditionProductGroupViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore()).ForMember(p => p.ProductGroupName, op => op.MapFrom(src => src.ProductGroup.GroupName));
            Mapper.CreateMap<LoyaltyRuleConditionValue, LoyaltyRuleConditionValueViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyActionType, LoyaltyActionTypeViewModel>().ForMember(p => p.UniqueId, opt => opt.MapFrom(src => src.Id)).ForMember(p => p.ID, opt => opt.Ignore());
            #endregion

        }

        private static void ConfigViewModelToModel()
        {
            #region
            Mapper.CreateMap<UserViewModel, User>();
            #endregion

            #region Base Data
            Mapper.CreateMap<CityRegionViewModel, CityRegion>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.CityRegion2Id, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString))).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseTypeViewModel, BaseType>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<BaseValueViewModel, BaseValue>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            #endregion

            #region Product
            Mapper.CreateMap<ProductGroupViewModel, ProductGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.ProductGroup2Id, opt => opt.MapFrom(src => ConvertNullableStringToGuid(src.ParentUniqueIdString))).ForMember(p => p.ProductGroup2Id, opt => opt.MapFrom(src => src.ParentUniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            #endregion

            #region Customer
            Mapper.CreateMap<CustomerShipAddressViewModel, CustomerShipAddress>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerViewModel, Customer>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId));
            Mapper.CreateMap<CustomerTagViewModel, CustomerTag>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore()).ForMember(p => p.ParentId, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString)));
            Mapper.CreateMap<CustomerGroupViewModel, CustomerGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore()).ForMember(p => p.ParentId, opt => opt.ResolveUsing(src => ConvertNullableStringToGuid(src.ParentUniqueIdString)));
            Mapper.CreateMap<CustomerNonMonetaryHistoryViewModel, CustomerNonMonetaryHistory>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerMonetaryHistoryViewModel, CustomerMonetaryHistory>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<CustomerTransactionHistoryViewModel, CustomerTransactionHistory>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            #endregion

            #region Loyalty
            Mapper.CreateMap<LoyaltyCardViewModel, LoyaltyCard>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyCardSetViewModel, LoyaltyCardSet>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTierViewModel, LoyaltyTier>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyUserGroupViewModel, UserGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTriggerViewModel, LoyaltyTrigger>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyTriggerTypeViewModel, LoyaltyTriggerType>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyValueTypeAttributeViewModel, LoyaltyValueTypeAttribute>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyProgramGroupViewModel, LoyaltyProgramGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleGroupViewModel, LoyaltyRuleGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyActionTypeViewModel, LoyaltyActionType>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleViewModel, LoyaltyRule>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleActionViewModel, LoyaltyRuleAction>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleTriggerViewModel, LoyaltyRuleTrigger>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleConditionViewModel, LoyaltyRuleCondition>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleConditionProductViewModel, LoyaltyRuleConditionProduct>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleConditionProductGroupViewModel, LoyaltyRuleConditionProductGroup>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());
            Mapper.CreateMap<LoyaltyRuleConditionValueViewModel, LoyaltyRuleConditionValue>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.UniqueId)).ForMember(p => p.Number_ID, opt => opt.Ignore());

            #endregion
        }
        private static Guid? ConvertNullableStringToGuid(string data)
        {
            var guid = Guid.Empty;
            Guid.TryParse(data, out guid);
            return guid;
        }

    }
}