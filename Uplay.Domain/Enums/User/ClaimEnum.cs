using System.ComponentModel;

namespace Uplay.Domain.Enums.User
{
    public enum ClaimEnum : byte
    {
        [Description("About_Post")]
        About_Post = 1,

        [Description("About_Put")]
        About_Put = 2,

        [Description("Branch_Delete")]
        Branch_Delete = 3,

        [Description("Branch_Disable")]
        Branch_Disable = 4,

        [Description("Category_Post")]
        Category_Post = 5,

        [Description("Branch_Statistics_Get")]
        Branch_Statistics_Get = 6,

        [Description("Branch_Qr_Retention_Get")]
        Branch_Qr_Retention_Get = 7,

        [Description("Contact_Get")]
        Contact_Get = 8,

        [Description("Contact_Details")]
        Contact_Details = 9,

        [Description("Faq_Post")]
        Faq_Post = 10,

        [Description("Faq_Put")]
        Faq_Put = 11,

        [Description("Faq_Delete")]
        Faq_Delete = 12,

        [Description("FeedbackType_Post")]
        FeedbackType_Post = 13,

        [Description("FeedbackType_Delete")]
        FeedbackType_Delete = 14,

        [Description("FeedbackType_Put")]
        FeedbackType_Put = 15,

        [Description("Partner_Post")]
        Partner_Post = 16,

        [Description("Partner_Delete")]
        Partner_Delete = 17,

        [Description("Partner_Put")]
        Partner_Put = 18,

        [Description("Playlist_Put")]
        Playlist_Put = 19,

        [Description("PublicReview_Post")]
        PublicReview_Post = 20,

        [Description("PublicReview_Delete")]
        PublicReview_Delete = 21,

        [Description("PublicReview_Put")]
        PublicReview_Put = 22,

        [Description("Service_Post")]
        Service_Post = 23,

        [Description("Service_Delete")]
        Service_Delete = 24,

        [Description("Service_Put")]
        Service_Put = 25,

        [Description("SocialLink_Post")]
        SocialLink_Post = 26,

        [Description("SocialLink_Put")]
        SocialLink_Put = 27,

        [Description("Company_Delete")]
        Company_Delete = 28,

        [Description("Add_User_Post")]
        Add_User_Post = 29,

        [Description("Get_All_Users")]
        Get_All_Users = 30,

        [Description("Category_Put")]
        Category_Put = 31,
        [Description("User_Put")]
        User_Put = 32,
        [Description("Pricing_Put")]
        Pricing_Put = 33,
        [Description("Review_Put")]
        Review_Put = 34,

        [Description("Get_User_Detail")]
        Get_User_Detail = 35,
    }
}
