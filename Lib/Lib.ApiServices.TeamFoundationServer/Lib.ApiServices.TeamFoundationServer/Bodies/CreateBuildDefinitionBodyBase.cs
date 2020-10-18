namespace Lib.ApiServices.TeamFoundationServer
{
    public abstract class CreateBuildDefinitionBodyBase
    {
        public string name { get; set; }
        public string type { get; set; }
        public string quality { get; set; }
        public string buildNumberFormat { get; set; }
        public string jobAuthorizationScope { get; set; }
        public Queue queue { get; set; }
        public Build[] build { get; set; }
        public object options { get; set; }
        public Repository repository { get; set; }
        public object[] triggers { get; set; }
        public string comment { get; set; }

        public VariablesBase variables { get; set; }

        public abstract class VariablesBase
        {
        }

        public class Queue
        {
            public int id { get; set; }
        }

        public class Repository
        {
            public string name { get; set; }
            public string type { get; set; }
            public string defaultBranch { get; set; }
            public string clean { get; set; }
            public bool checkoutSubmodules { get; set; }
        }

        public class Build
        {
            public bool enabled { get; set; }
            public bool continueOnError { get; set; }
            public bool alwaysRun { get; set; }
            public string displayName { get; set; }
            public Task task { get; set; }
            public Inputs inputs { get; set; }
        }

        public class Task
        {
            public string id { get; set; }
            public string versionSpec { get; set; }
        }

        public class Inputs
        {
            public string SourceFolder { get; set; }
            public string Contents { get; set; }
            public string solution { get; set; }
            public string nugetConfigPath { get; set; }
            public string noCache { get; set; }
            public string nuGetRestoreArgs { get; set; }
            public string nuGetPath { get; set; }
            public string scriptName { get; set; }
            public string arguments { get; set; }
            public string workingFolder { get; set; }
            public string platform { get; set; }
            public string configuration { get; set; }
            public string msbuildArguments { get; set; }
            public string clean { get; set; }
            public string restoreNugetPackages { get; set; }
            public string logProjectEvents { get; set; }
            public string msbuildLocationMethod { get; set; }
            public string msbuildVersion { get; set; }
            public string msbuildArchitecture { get; set; }
            public string msbuildLocation { get; set; }
            public string testRunner { get; set; }
            public string testResultsFiles { get; set; }
            public string mergeTestResults { get; set; }
            public string testRunTitle { get; set; }
            public string publishRunAttachments { get; set; }
            public string failOnStandardError { get; set; }
            public string filename { get; set; }
            public string ArtifactName { get; set; }
            public string ArtifactType { get; set; }
            public string PathtoPublish { get; set; }
            public string TargetPath { get; set; }
        }
    }
}
