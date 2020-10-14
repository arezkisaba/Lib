namespace Lib.Core.OnlineServices.Unibet
{
    public class GetBetsResponse
    {
        public int betslipmaxcount { get; set; }
        public int betslipcount { get; set; }
        public Betleg[] betlegs { get; set; }
        public bool singleAllowed { get; set; }
        public bool multipleAllowed { get; set; }
        public bool systemsAllowed { get; set; }

        public class Betleg
        {
            public string selectionId { get; set; }
            public int priceUp { get; set; }
            public int priceDown { get; set; }
            public object lowerBand { get; set; }
            public object upperBand { get; set; }
            public object handicap { get; set; }
            public string priceType { get; set; }
            public string marketId { get; set; }
            public string eventId { get; set; }
            public string eventName { get; set; }
            public string selectionName { get; set; }
            public object competitionId { get; set; }
            public object eventDate { get; set; }
            public string marketName { get; set; }
            public string[] availablePriceTypes { get; set; }
            public object[][] eachWayTerms { get; set; }
            public object liveEventId { get; set; }
            public object isWinning { get; set; }
            public object isRunning { get; set; }
            public object isCancel { get; set; }
            public string sportType { get; set; }
            public object cmsSportName { get; set; }
            public object cmsSportId { get; set; }
            public object isCB { get; set; }
            public object competitionAlertEmail { get; set; }
            public object competitionAlertAmount { get; set; }
            public object betStateName { get; set; }
            public object winWLDOutcome { get; set; }
            public object isCashoutAvailable { get; set; }
        }
    }
}
