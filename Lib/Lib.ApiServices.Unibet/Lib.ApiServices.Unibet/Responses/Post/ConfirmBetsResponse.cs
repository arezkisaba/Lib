namespace Lib.ApiServices.Unibet
{
    public class ConfirmBetsResponse
    {
        public Betoutbound betoutbound { get; set; }

        public class Betoutbound
        {
            public int state { get; set; }
            public object statusCode { get; set; }
            public object statusText { get; set; }
            public string[] detailedStates { get; set; }
            public string[] detailedStatesValues { get; set; }
            public bool reoffered { get; set; }
            public object inrunning { get; set; }
            public int totalLegs { get; set; }
            public bool isConfirmed { get; set; }
            public bool alreadyCommitted { get; set; }
            public float totalStake { get; set; }
            public object totalStakeReoffered { get; set; }
            public float totalPotentialReturn { get; set; }
            public object totalPotentialReturnReoffered { get; set; }
            public Betoutbound1[] betOutbounds { get; set; }
            public object alertEmails { get; set; }
            public object alertEvents { get; set; }
            public string externalReference { get; set; }
            public string betSlipKey { get; set; }
            public object alertForbiddenCompetitions { get; set; }
            public object alertEvent { get; set; }
            public int idfobetSlip { get; set; }
            public object forbiddenCompetition { get; set; }
        }

        public class Betoutbound1
        {
            public string type { get; set; }
            public Betleg[] betlegs { get; set; }
            public float stake { get; set; }
            public object stakeReoffered { get; set; }
            public float totalStake { get; set; }
            public object totalStakeReoffered { get; set; }
            public float potentialReturn { get; set; }
            public string externalReference { get; set; }
            public bool reoffered { get; set; }
            public bool isCashoutAvailable { get; set; }
        }

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
            public object marketName { get; set; }
            public object availablePriceTypes { get; set; }
            public object eachWayTerms { get; set; }
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
            public object priceReofferedUp { get; set; }
            public object priceReofferedDown { get; set; }
            public object handicapReoffered { get; set; }
            public object reoffered { get; set; }
        }
    }
}
