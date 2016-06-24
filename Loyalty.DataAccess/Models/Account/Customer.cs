using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Anatoli.DataAccess.Models;

namespace Loyalty.DataAccess.Models.Account
{
    public class Customer : LoyaltyBaseModel
    {
        [StringLength(50)]
        public string CustomerCode { get; set; }
        [StringLength(200)]
        public string CustomerName { get; set; }
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        public string PostalCode { get; set; }

        public bool Gender { get; set; }

        [StringLength(20)]
        public string NationalCode { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string Mobile { get; set; }
        [StringLength(500)]
        public string Email { get; set; }
        [StringLength(500)]
        public string MainStreet { get; set; }
        [StringLength(500)]
        public string OtherStreet { get; set; }
        public double Longitude { set; get; }
        public double Latitude { set; get; }
        [ForeignKey("RegionInfo"), Column(Order = 0)]
        public Nullable<Guid> RegionInfoId { get; set; }
        [ForeignKey("RegionLevel1"), Column(Order = 1)]
        public Nullable<Guid> RegionLevel1Id { get; set; }
        [ForeignKey("RegionLevel2"), Column(Order = 2)]
        public Nullable<Guid> RegionLevel2Id { get; set; }
        [ForeignKey("RegionLevel3"), Column(Order = 3)]
        public Nullable<Guid> RegionLevel3Id { get; set; }
        [ForeignKey("RegionLevel4"), Column(Order = 4)]
        public Nullable<Guid> RegionLevel4Id { get; set; }


        [ForeignKey("CustomerType")]
        public Nullable<Guid> CustomerTypeId { get; set; }
        [ForeignKey("LoyaltyTier")]
        public Nullable<Guid> LoyaltyTierId { get; set; }
        [ForeignKey("CustomerGroup")]
        public Nullable<Guid> CustomerGroupId { get; set; }
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<CustomerShipAddress> CustomerShipAddresses { get; set; }
        public virtual ICollection<LoyaltyCard> LoyaltyCards { get; set; }
        public virtual ICollection<CustomerTagCustomer> CustomerTags { get; set; }
       
        public virtual ICollection<CustomerLoyaltyTierHistory> CustomerLoyaltyTierHistories { get; set; }
        public virtual CityRegion RegionInfo { get; set; }
        public virtual CityRegion RegionLevel1 { get; set; }
        public virtual CityRegion RegionLevel2 { get; set; }
        public virtual CityRegion RegionLevel3 { get; set; }
        public virtual CityRegion RegionLevel4 { get; set; }
        public virtual LoyaltyTier LoyaltyTier { get; set; }
        public virtual CustomerGroup CustomerGroup { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public Nullable<DateTime> BirthDay { get; set; }
        public string PBirthDay { get; set; }
        public Nullable<DateTime> MarriageDate { get; set; }
        public string PMarriageDate { get; set; }

        public Nullable<DateTime> GraduateDate { get; set; }
        public string PGraduateDate { get; set; }

        public Nullable<Guid> ReagentId { get; set; }

        public bool GetNews { get; set; }
        public bool GetMessage { get; set; }

        public int Status { get; set; }

    }
}
