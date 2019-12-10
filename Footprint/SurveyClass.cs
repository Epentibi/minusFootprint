using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Footprint.Base.lproj;
using System.Reflection;
using System.Linq;

namespace Footprint
{
    public class SurveyClass
    {
        public string name;
        public string id;
        public int challengeTopicIndex;

        public int AdditionalValue;

        public class SurveyModule
        {
            public string moduleID;
            public string questions;
            public Dictionary<string, int> additionalValues = new Dictionary<string, int>();
            public Dictionary<string, string> responses = new Dictionary<string, string>();
            public Dictionary<string, int> returnValues = new Dictionary<string, int>();
        }

        public List<SurveyModule> surveyModules = new List<SurveyModule>();

        public SurveyView surveyView;

        public void Start(SurveyView view)
        {
            view.module = getModuleByID("0");
            surveyView = view;
            view.surveyClass = this;
        }

        public SurveyModule getModuleByID(string id)
        {
            foreach(SurveyModule module in surveyModules)
            {
                if(module.moduleID == id)
                {
                    return module;
                }
            }
            return null;
        }

        public void CompleteSurvey(string id, SurveyView nextView, SurveyModule surveyModule, string key)
        {
            if(id == "complete")
            {
                System.Diagnostics.Debug.WriteLine("survey " + id + " completed  with the return value of " + (surveyModule.returnValues[key] + AdditionalValue) + " for challenge topic index " + challengeTopicIndex);
                Filewrite.AddSurveyResult(challengeTopicIndex.ToString(), surveyModule.returnValues[key] + AdditionalValue);
                nextView.DismissAll();
                return;
            }
            if(surveyModule.additionalValues.ContainsKey(key))
            {
                AdditionalValue += surveyModule.additionalValues[key];
            }
            nextView.surveyClass = this;
            nextView.module = getModuleByID(id);
            surveyView.NavigationController.PushViewController(nextView, true);
            surveyView = nextView;
        }

        public SurveyClass(string surveyName)
        {

            var assembly = Assembly.GetExecutingAssembly();

            System.Diagnostics.Debug.WriteLine(surveyName);

            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(surveyName));

            Stream stream = assembly.GetManifestResourceStream(resourceName);

            XmlReader xtr = XmlReader.Create(stream);

            SurveyModule survey = null;

            string key = null;

            while(xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "survey")
                {
                    id = xtr.GetAttribute("id");
                    name = xtr.GetAttribute("name");
                    challengeTopicIndex = int.Parse(xtr.GetAttribute("topic"));
                    System.Diagnostics.Debug.WriteLine("name is " +  name + ", bound to solve index " + challengeTopicIndex);
                }

                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "id")
                {
                    if(survey != null)
                    {
                        surveyModules.Add(survey);
                    }
                    survey = new SurveyModule();
                    survey.moduleID = xtr.ReadElementContentAsString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "question")
                {
                    survey.questions = xtr.ReadElementContentAsString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "description")
                {
                    key = xtr.ReadElementContentAsString();
                    survey.responses.Add(key, null);
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "jumpID")
                {
                    survey.responses[key] = xtr.ReadElementContentAsString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "returnValue")
                {
                    survey.returnValues.Add(key, xtr.ReadElementContentAsInt());
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "additionalValue")
                {
                    survey.additionalValues.Add(key, xtr.ReadElementContentAsInt());
                }
            }

            surveyModules.Add(survey);

             /*
            foreach (SurveyModule d in surveyModules)
            {
                System.Diagnostics.Debug.WriteLine(d.moduleID);
                System.Diagnostics.Debug.WriteLine(d.questions);
                foreach (KeyValuePair<string, string> entry in d.responses)
                {
                    System.Diagnostics.Debug.WriteLine(entry.Key);
                    System.Diagnostics.Debug.WriteLine(entry.Value);
                }
            }*/
        }
    }
}
