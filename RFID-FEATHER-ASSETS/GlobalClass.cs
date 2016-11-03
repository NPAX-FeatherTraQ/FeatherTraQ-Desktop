using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFID_FEATHER_ASSETS
{
    class GlobalClass
    {
        public class GetSetClass
        {
            public int assetId { get; set; }
            public int companyId { get; set; }
            public int registerUserId { get; set; }
            public int userId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string imageUrls { get; set; }
            public string imageUrl { get; set; }
            public string tag { get; set; }
            public int tagType { get; set; }
            public bool takeOutAllowed { get; set; }
            public string takeOutInfo { get; set; }
            public DateTime? validUntil { get; set; }
            public DateTime? startDate { get; set; }
            public string response { get; set; }
            public string message { get; set; }
            public string result { get; set; }
            public int ownerId { get; set; }
            public int ownerUserId { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime? validUntilNullable { get; set; }
            public int updateUserId { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string companyName { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string authenticationToken { get; set; }
            public string roles { get; set; }
            public int readerId { get; set; }
            public string notes { get; set; }
            public string readerInfo { get; set; }
            public int transactionId { get; set; }
            public DateTime createdAt { get; set; }
            public AssetList asset { get; set; }
            public string position { get; set; }
            public string authorities { get; set; }
            AssetList assetDto = new AssetList();
            public string confirmPassword { get; set; }
            public AssetList assetIdCard = new AssetList();
            public string roleName { get; set; }
            public string value { get; set; }
            public string type { get; set; }
            public string ownerName { get; set; }
            public string updatedBy { get; set; }
            public string userType { get; set; }
            public string takeOutNote { get; set; }
            public string validityPeriod { get; set; }
            public string ownerImageUrl { get; set; }
            public string assetImageUrl { get; set; }
            public string assetType { get; set; }
            public string baseLocation { get; set; }
            public string location { get; set; }
            public string classType { get; set; }
        }

        public class AssetList
        {
            public int? assetId { get; set; }
            public int? companyId { get; set; }
            public int registerUserId { get; set; }
            public int updateUserId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string imageUrls { get; set; }
            public string tag { get; set; }
            public string takeOutInfo { get; set; }
            public bool takeOutAllowed { get; set; }
            public DateTime updatedAt { get; set; }
            public DateTime? validUntil { get; set; }
            public DateTime? startDate { get; set; }
            public int ownerId { get; set; }
            public int tagType { get; set; }
            public int ownerUserId { get; set; }
            public string assetType { get; set; }
            public string baseLocation { get; set; }
        }

        public class TypeList
        {
            public string type { get; set; }
        }
        public class LocationList
        {
            public string location { get; set; }
        }

    }
}
