namespace ConsoleAppWorkingSearch
{
    using System;
    using System.Text;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Spatial;
    using Newtonsoft.Json;

    // The SerializePropertyNamesAsCamelCase attribute is defined in the Azure Search .NET SDK.
    // It ensures that Pascal-case property names in the model class are mapped to camel-case
    // field names in the index.
    [SerializePropertyNamesAsCamelCase]
    public partial class Hotel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [IsFilterable]
        public string HotelId { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public double? BaseRate { get; set; }

        [IsSearchable]
        public string Description { get; set; }

        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.FrLucene)]
        [JsonProperty("description_fr")]
        public string DescriptionFr { get; set; }

        [IsSearchable, IsFilterable, IsSortable]
        public string HotelName { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public string Category { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public string[] Tags { get; set; }

        [IsFilterable, IsFacetable]
        public bool? ParkingIncluded { get; set; }

        [IsFilterable, IsFacetable]
        public bool? SmokingAllowed { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public DateTimeOffset? LastRenovationDate { get; set; }
   
        [IsFilterable, IsSortable, IsFacetable]
        public int? Rating { get; set; }

        [IsFilterable, IsSortable]
        public GeographyPoint Location { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if (!String.IsNullOrEmpty(HotelId))
            {
                builder.AppendFormat("ID: {0}\t", HotelId);
            }

            if (BaseRate.HasValue)
            {
                builder.AppendFormat("Base rate: {0}\t", BaseRate);
            }

            if (!String.IsNullOrEmpty(Description))
            {
                builder.AppendFormat("Description: {0}\t", Description);
            }

            if (!String.IsNullOrEmpty(DescriptionFr))
            {
                builder.AppendFormat("Description (French): {0}\t", DescriptionFr);
            }

            if (!String.IsNullOrEmpty(HotelName))
            {
                builder.AppendFormat("Name: {0}\t", HotelName);
            }

            if (!String.IsNullOrEmpty(Category))
            {
                builder.AppendFormat("Category: {0}\t", Category);
            }

            if (Tags != null && Tags.Length > 0)
            {
                builder.AppendFormat("Tags: [{0}]\t", String.Join(", ", Tags));
            }

            if (ParkingIncluded.HasValue)
            {
                builder.AppendFormat("Parking included: {0}\t", ParkingIncluded.Value ? "yes" : "no");
            }

            if (SmokingAllowed.HasValue)
            {
                builder.AppendFormat("Smoking allowed: {0}\t", SmokingAllowed.Value ? "yes" : "no");
            }

            if (LastRenovationDate.HasValue)
            {
                builder.AppendFormat("Last renovated on: {0}\t", LastRenovationDate);
            }

            if (Rating.HasValue)
            {
                builder.AppendFormat("Rating: {0}/5\t", Rating);
            }

            if (Location != null)
            {
                builder.AppendFormat("Location: Latitude {0}, longitude {1}\t", Location.Latitude, Location.Longitude);
            }

            return builder.ToString();
        }
    }

    //public override string ToString()
    //{
    //    return $"Hotel Id : {HotelId}\nBase Rate : {BaseRate}\nDescription : {Description}\nDescription fr : {DescriptionFr}" +
    //        $"\nHotel Name : {HotelName}\nCategory : {Category}\nTags : {Tags}\nParking Included ; {ParkingIncluded}" +
    //        $"\nSmoking Allowed : {SmokingAllowed}\nLast Renovation Date : {LastRenovationDate}\nRating : {Rating}" +
    //        $"\nLocation : {Location}";
    //}
}
