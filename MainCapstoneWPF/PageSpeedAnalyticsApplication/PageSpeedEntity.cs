using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSpeedAnalyticsApplication
{
    /// <summary>
    /// Data Model Class for Page Speed Response Storage
    /// </summary>
    public class PageSpeedEntity
    {
        /// <summary>
        /// URL this object is based on
        /// </summary>
        public string Base_URL { get; set; }
        /// <summary>
        /// original structure of response returned from google
        /// </summary>
        public Google.Apis.Pagespeedonline.v4.Data.PagespeedApiPagespeedResponseV4 Result { get; set; }
        /// <summary>
        /// Speed Score from Response
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Date of Request/Response
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Strategy used; 0 = Desktop, 1 = Mobile
        /// </summary>
        public int Strategy { get; set; }

    }

    //public class PagespeedApiPagespeedResponseV4
    //{
    //    public virtual string CaptchaResult { get; set; }
    //    public virtual string ETag { get; set; }
    //    public virtual PagespeedApiPagespeedResponseV4.FormattedResultsData FormattedResults { get; set; }
    //    public virtual string Id { get; set; }
    //    public virtual IList<string> InvalidRules { get; set; }
    //    public virtual string Kind { get; set; }
    //    public virtual PagespeedApiPagespeedResponseV4.LoadingExperienceData LoadingExperience { get; set; }
    //    public virtual PagespeedApiPagespeedResponseV4.PageStatsData PageStats { get; set; }
    //    public virtual int? ResponseCode { get; set; }
    //    public virtual IDictionary<string, PagespeedApiPagespeedResponseV4.RuleGroupsDataElement> RuleGroups { get; set; }
    //    public virtual PagespeedApiImageV4 Screenshot { get; set; }
    //    public virtual IList<PagespeedApiImageV4> Snapshots { get; set; }
    //    public virtual string Title { get; set; }
    //    public virtual PagespeedApiPagespeedResponseV4.VersionData Version { get; set; }
    //    public PagespeedApiPagespeedResponseV4() { }
    //    public class FormattedResultsData
    //    {
    //        public class RuleResultsDataElement
    //        {
    //            public class UrlBlocksData
    //            {
    //                public class UrlsData
    //                {
    //                    public virtual IList<PagespeedApiFormatStringV4> Details { get; set; }
    //                    public virtual PagespeedApiFormatStringV4 Result { get; set; }
    //                    public UrlsData() { }
    //                }
    //                public virtual PagespeedApiFormatStringV4 Header { get; set; }
    //                public virtual IList<PagespeedApiPagespeedResponseV4.FormattedResultsData.RuleResultsDataElement.UrlBlocksData.UrlsData> Urls { get; set; }
    //                public UrlBlocksData() { }
    //            }
    //            public virtual bool? Beta { get; set; }
    //            public virtual IList<string> Groups { get; set; }
    //            public virtual string LocalizedRuleName { get; set; }
    //            public virtual double? RuleImpact { get; set; }
    //            public virtual PagespeedApiFormatStringV4 Summary { get; set; }
    //            public virtual IList<PagespeedApiPagespeedResponseV4.FormattedResultsData.RuleResultsDataElement.UrlBlocksData> UrlBlocks { get; set; }
    //            public RuleResultsDataElement() { }
    //        }
    //        public virtual string Locale { get; set; }
    //        public virtual IDictionary<string, PagespeedApiPagespeedResponseV4.FormattedResultsData.RuleResultsDataElement> RuleResults { get; set; }
    //        public FormattedResultsData() { }
    //    }
    //    public class LoadingExperienceData
    //    {
    //        public class MetricsDataElement
    //        {
    //            public class DistributionsData
    //            {
    //                public virtual int? Max { get; set; }
    //                public virtual int? Min { get; set; }
    //                public virtual double? Proportion { get; set; }
    //                public DistributionsData() { }
    //            }
    //            public virtual string Category { get; set; }
    //            public virtual IList<PagespeedApiPagespeedResponseV4.LoadingExperienceData.MetricsDataElement.DistributionsData> Distributions { get; set; }
    //            public virtual int? Median { get; set; }
    //            public MetricsDataElement() { }
    //        }
    //        public virtual string Id { get; set; }
    //        public virtual string InitialUrl { get; set; }
    //        public virtual IDictionary<string, PagespeedApiPagespeedResponseV4.LoadingExperienceData.MetricsDataElement> Metrics { get; set; }
    //        public virtual string OverallCategory { get; set; }
    //        public LoadingExperienceData() { }
    //    }
    //    public class PageStatsData
    //    {
    //        public virtual string Cms { get; set; }
    //        public virtual long? CssResponseBytes { get; set; }
    //        public virtual long? FlashResponseBytes { get; set; }
    //        public virtual long? HtmlResponseBytes { get; set; }
    //        public virtual long? ImageResponseBytes { get; set; }
    //        public virtual long? JavascriptResponseBytes { get; set; }
    //        public virtual int? NumRenderBlockingRoundTrips { get; set; }
    //        public virtual int? NumTotalRoundTrips { get; set; }
    //        public virtual int? NumberCssResources { get; set; }
    //        public virtual int? NumberHosts { get; set; }
    //        public virtual int? NumberJsResources { get; set; }
    //        public virtual int? NumberResources { get; set; }
    //        public virtual int? NumberRobotedResources { get; set; }
    //        public virtual int? NumberStaticResources { get; set; }
    //        public virtual int? NumberTransientFetchFailureResources { get; set; }
    //        public virtual long? OtherResponseBytes { get; set; }
    //        public virtual long? OverTheWireResponseBytes { get; set; }
    //        public virtual IList<string> RobotedUrls { get; set; }
    //        public virtual long? TextResponseBytes { get; set; }
    //        public virtual long? TotalRequestBytes { get; set; }
    //        public virtual IList<string> TransientFetchFailureUrls { get; set; }
    //        public PageStatsData() { }
    //    }
    //    public class RuleGroupsDataElement
    //    {
    //        public virtual bool? Pass { get; set; }
    //        public virtual int? Score { get; set; }
    //        public RuleGroupsDataElement() { }
    //    }
    //    public class VersionData
    //    {
    //        public virtual int? Major { get; set; }
    //        public virtual int? Minor { get; set; }
    //        public VersionData() { }
    //    }
    //}

    //public class PagespeedApiFormatStringV4
    //{
    //    public PagespeedApiFormatStringV4() { }

    //    // public IList<ArgsData> Args { get; set; }
    //    public IList<PagespeedApiFormatStringV4.ArgsData> Args { get; set; }
    //    public string ETag { get; set; }
    //    public string Format { get; set; }

    //    public class ArgsData
    //    {
    //        public class RectsData
    //        {
    //            public int Height { get; set; }
    //            public int Left { get; set; }
    //            public int Top { get; set; }
    //            public int Width { get; set; }
    //        }
    //        public class SecondaryRectsData
    //        {
    //            public int Height { get; set; }
    //            public int Left { get; set; }
    //            public int Top { get; set; }
    //            public int Width { get; set; }
    //        }
    //        public string Key { get; set; }
    //        public IList<PagespeedApiFormatStringV4.ArgsData.RectsData> Rects { get; set; }
    //        public IList<PagespeedApiFormatStringV4.ArgsData.SecondaryRectsData> Secondary_rects { get; set; }
    //        public string Type { get; set; }
    //        public string Value { get; set; }
    //        //public string ArgsDataType { get; set; }
    //    }
    //}
    //public class PagespeedApiImageV4
    //{
    //    public virtual string Data { get; set; }
    //    public virtual string ETag { get; set; }
    //    public virtual int? Height { get; set; }
    //    public virtual string Key { get; set; }
    //    public virtual string MimeType { get; set; }
    //    public virtual PagespeedApiImageV4.PageRectData PageRect { get; set; }
    //    public virtual int? Width { get; set; }
    //    public PagespeedApiImageV4 () { }
    //    public class PageRectData
    //    {
    //        public virtual int? Height { get; set; }
    //        public virtual int? Left { get; set; }
    //        public virtual int? Top { get; set; }
    //        public virtual int? Width { get; set; }
    //        public PageRectData () { }
    //    }
    //} 
}
