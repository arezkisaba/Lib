using System;

namespace Lib.ApiServices.TeamFoundationServer
{
    public abstract class CreateReleaseDefinitionBodyBase
    {
        public int id { get; set; }
        public int revision { get; set; }
        public string name { get; set; }
        public Createdby createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public Modifiedby modifiedBy { get; set; }
        public DateTime modifiedOn { get; set; }
        public VariablesReleaseBase variables { get; set; }
        public Environment[] environments { get; set; }
        public Artifact[] artifacts { get; set; }
        public Trigger[] triggers { get; set; }
        public string releaseNameFormat { get; set; }
        public Retentionpolicy retentionPolicy { get; set; }

        public abstract class VariablesReleaseBase
        {
        }

        public abstract class VariablesEnvironmentBase
        {
        }

        public class Createdby
        {
            public string id { get; set; }
            public string displayName { get; set; }
        }

        public class Modifiedby
        {
            public string id { get; set; }
            public string displayName { get; set; }
        }

        public class Retentionpolicy
        {
            public int daysToKeep { get; set; }
        }

        public class Environment
        {
            public int id { get; set; }
            public string name { get; set; }
            public int rank { get; set; }
            public Owner owner { get; set; }
            public VariablesEnvironmentBase variables { get; set; }
            public Predeployapprovals preDeployApprovals { get; set; }
            public Deploystep deployStep { get; set; }
            public Postdeployapprovals postDeployApprovals { get; set; }
            public int queueId { get; set; }
            public Runoptions runOptions { get; set; }
            public object[] demands { get; set; }
            public Condition[] conditions { get; set; }
            public Executionpolicy executionPolicy { get; set; }
        }

        public class Owner
        {
            public string id { get; set; }
            public string displayName { get; set; }
        }

        public class Predeployapprovals
        {
            public Approval[] approvals { get; set; }
        }

        public class Approval
        {
            public int rank { get; set; }
            public bool isAutomated { get; set; }
            public bool isNotificationOn { get; set; }
            public int id { get; set; }
        }

        public class Deploystep
        {
            public Task[] tasks { get; set; }
            public int id { get; set; }
        }

        public class Task
        {
            public string taskId { get; set; }
            public string version { get; set; }
            public string name { get; set; }
            public bool enabled { get; set; }
            public bool alwaysRun { get; set; }
            public bool continueOnError { get; set; }
            public Inputs inputs { get; set; }
        }

        public class Inputs
        {
            public string sourceFolder { get; set; }
            public string contents { get; set; }
            public string targetFolder { get; set; }
            public string cleanTargetFolder { get; set; }
            public string overWrite { get; set; }
            public string scriptName { get; set; }
            public string arguments { get; set; }
            public string workingFolder { get; set; }
            public string solution { get; set; }
            public string nugetConfigPath { get; set; }
            public string noCache { get; set; }
            public string nuGetRestoreArgs { get; set; }
            public string nuGetPath { get; set; }
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
            public string filename { get; set; }
        }

        public class Postdeployapprovals
        {
            public Approval1[] approvals { get; set; }
        }

        public class Approval1
        {
            public int rank { get; set; }
            public bool isAutomated { get; set; }
            public bool isNotificationOn { get; set; }
            public int id { get; set; }
        }

        public class Runoptions
        {
            public string environmentOwnerEmailNotificationType { get; set; }
            public string skipArtifactsDownload { get; set; }
            public string timeoutInMinutes { get; set; }
        }

        public class Executionpolicy
        {
            public int concurrencyCount { get; set; }
            public int queueDepthCount { get; set; }
        }

        public class Condition
        {
            public string name { get; set; }
            public int conditionType { get; set; }
            public string value { get; set; }
        }

        public class Artifact
        {
            public int id { get; set; }
            public string type { get; set; }
            public string alias { get; set; }
            public Definitionreference definitionReference { get; set; }
        }

        public class Definitionreference
        {
            public Definition definition { get; set; }
            public Project project { get; set; }
        }

        public class Definition
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Project
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Trigger
        {
            public int triggerType { get; set; }
            public string artifactAlias { get; set; }
            public object schedule { get; set; }
        }
    }
}
