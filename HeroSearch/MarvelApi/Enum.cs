using System;
using System.ComponentModel;
using System.Reflection;

namespace HeroSearch.MarvelApi
{
    public enum ComicFormat
    {
        Comic,
        Magazine,
        TradePaperback,
        Hardcover,
        Digest,
        GraphicNovel,
        DigitalComic,
        InfiniteComic
    }

    public enum ComicFormatType
    {
        Comic,
        Collection
    }

    public enum SeriesType
    {
        Collection,
        OneShot,
        Limited,
        Ongoing
    }

    public enum DateDescriptor
    {
        LastWeek,
        ThisWeek,
        NextWeek,
        ThisMonth
    }

    public enum OrderBy
    {
        FocDate,
        FocDateDesc,
        OnSaleDate,
        OnSaleDateDesc,
        Title,
        TitleDesc,
        IssueNumber,
        IssueNumberDesc,
        Modified,
        ModifiedDesc,
        Id,
        IdDesc,
        Name,
        NameDesc,
        StartDate,
        StartDateDesc,
        FirstName,
        FirstNameDesc,
        MiddleName,
        MiddleNameDesc,
        LastName,
        LastNameDesc,
        Suffix,
        SuffixDesc,
        StartYear,
        StartYearDesc
    }

    public enum Image
    {

        [Description("50x75px")]
        PortraitSmall,
        [Description("100x150px")]
        PortraitMedium,
        [Description("150x225px")]
        PortraitXlarge,
        [Description("168x252px")]
        PortraitFantastic,
        [Description("300x450px")]
        PortraitUncanny,
        [Description("216x324px")]
        PortraitIncredible,

        [Description("65x45px")]
        StandardSmall,
        [Description("100x100px")]
        StandardMedium,
        [Description("140x140px")]
        StandardLarge,
        [Description("200x200px")]
        StandardXlarge,
        [Description("250x250px")]
        StandardFantastic,
        [Description("180x180px")]
        StandardAmazing,

        [Description("120x90px")]
        LandscapeSmall,
        [Description("175x130px")]
        LandscapeMedium,
        [Description("190x140px")]
        LandscapeLarge,
        [Description("270x200px")]
        LandscapeXlarge,
        [Description("250x156px")]
        LandscapeAmazing,
        [Description("464x261px")]
        LandscapeIncredible,

        [Description("full image, constrained to 500px wide")]
        Detail,
        [Description("no variant descriptor")]
        Full
    }

    public static class EnumExtensions
    {
        public static string ToParameter(this ComicFormat Format)
        {
            switch (Format)
            {
                case ComicFormat.Comic:
                    return "comic";
                case ComicFormat.Digest:
                    return "digest";
                case ComicFormat.DigitalComic:
                    return "digital comic";
                case ComicFormat.GraphicNovel:
                    return "graphic novel";
                case ComicFormat.Hardcover:
                    return "hardcover";
                case ComicFormat.InfiniteComic:
                    return "infinite comic";
                case ComicFormat.Magazine:
                    return "magazine";
                case ComicFormat.TradePaperback:
                    return "trade paperback";
                default:
                    return String.Empty;
            }
        }

        public static string ToParameter(this ComicFormatType FormatType)
        {
            switch (FormatType)
            {
                case ComicFormatType.Collection:
                    return "collection";
                case ComicFormatType.Comic:
                    return "comic";
                default:
                    return String.Empty;
            }
        }

        public static string ToParameter(this SeriesType Type)
        {
            switch (Type)
            {
                case SeriesType.Collection:
                    return "collection";
                case SeriesType.OneShot:
                    return "one shot";
                case SeriesType.Limited:
                    return "limited";
                case SeriesType.Ongoing:
                    return "ongoing";
                default:
                    return String.Empty;
            }
        }

        public static string ToParameter(this DateDescriptor Descriptor)
        {
            switch (Descriptor)
            {
                case DateDescriptor.LastWeek:
                    return "lastWeek";
                case DateDescriptor.NextWeek:
                    return "nextWeek";
                case DateDescriptor.ThisMonth:
                    return "thisMonth";
                case DateDescriptor.ThisWeek:
                    return "thisWeek";
                default:
                    return String.Empty;
            }
        }

        public static string ToParameter(this OrderBy Order)
        {
            switch (Order)
            {
                case OrderBy.FocDate:
                    return "focDate";
                case OrderBy.FocDateDesc:
                    return "-focDate";
                case OrderBy.IssueNumber:
                    return "issueNumber";
                case OrderBy.IssueNumberDesc:
                    return "-issueNumber";
                case OrderBy.Modified:
                    return "modified";
                case OrderBy.ModifiedDesc:
                    return "-modified";
                case OrderBy.OnSaleDate:
                    return "onsaleDate";
                case OrderBy.OnSaleDateDesc:
                    return "-onsaleDate";
                case OrderBy.Title:
                    return "title";
                case OrderBy.TitleDesc:
                    return "-title";
                case OrderBy.Id:
                    return "id";
                case OrderBy.IdDesc:
                    return "-id";
                case OrderBy.Name:
                    return "name";
                case OrderBy.NameDesc:
                    return "-name";
                case OrderBy.StartDate:
                    return "startDate";
                case OrderBy.StartDateDesc:
                    return "-startDate";
                case OrderBy.FirstName:
                    return "firstName";
                case OrderBy.FirstNameDesc:
                    return "-firstName";
                case OrderBy.MiddleName:
                    return "middleName";
                case OrderBy.MiddleNameDesc:
                    return "-middleName";
                case OrderBy.LastName:
                    return "lastName";
                case OrderBy.LastNameDesc:
                    return "-lastName";
                case OrderBy.Suffix:
                    return "suffix";
                case OrderBy.SuffixDesc:
                    return "-suffix";
                case OrderBy.StartYear:
                    return "startYear";
                case OrderBy.StartYearDesc:
                    return "-startYear";
                default:
                    return String.Empty;
            }
        }

        public static string ToParameter(this Image image)
        {
            switch (image)
            {
                case Image.PortraitSmall:
                    return "/portrait_small";
                case Image.PortraitMedium:
                    return "/portrait_medium";
                case Image.PortraitXlarge:
                    return "/portrait_xlarge";
                case Image.PortraitFantastic:
                    return "/portrait_fantastic";
                case Image.PortraitUncanny:
                    return "/portrait_uncanny";
                case Image.PortraitIncredible:
                    return "/portrait_incredible";

                case Image.StandardSmall:
                    return "/standard_small";
                case Image.StandardMedium:
                    return "/standard_medium";
                case Image.StandardLarge:
                    return "/standard_large";
                case Image.StandardXlarge:
                    return "/standard_xlarge";
                case Image.StandardFantastic:
                    return "/standard_fantastic";
                case Image.StandardAmazing:
                    return "/standard_amazing";
                case Image.LandscapeSmall:
                    return "/landscape_small";
                case Image.LandscapeMedium:
                    return "/landscape_medium";
                case Image.LandscapeLarge:
                    return "/landscape_large";
                case Image.LandscapeXlarge:
                    return "/landscape_xlarge";
                case Image.LandscapeAmazing:
                    return "/landscape_amazing";
                case Image.LandscapeIncredible:
                    return "/landscape_incredible";

                case Image.Detail:
                    return "/detail";
                default:
                    return "";
            }
        }

        public static
            string Description<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }
    }
}
