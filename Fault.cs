using System;
using System.Collections.Generic;

namespace AlertsProject
{
    [Serializable]
    public class Fault
    {
        private string name;
        private string implication;
        private string solution;
        private List<SystemComponent> affectedComponents;

        public Fault(string name, string implication)
        {
            this.name = name;
            this.implication = implication;
        }

        public Fault(string name, string implication, string solution, List<SystemComponent> affectedComponents)
        {
            this.name = name;
            this.implication = implication;
            this.solution = solution;
            this.affectedComponents = affectedComponents;
        }

        public Fault()
        {
            this.name = "";
            this.implication = "";
            this.solution = "";
            this.affectedComponents = new List<SystemComponent>();
        }

        public string getName()
        {
            return this.name;
        }

        public string getimplication()
        {
            return this.implication;
        }

        public string getSolution()
        {
            return this.implication;
        }
        public List<SystemComponent> getAffectedComponents()
        {
            return this.affectedComponents;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setImplications(string implication)
        {
            this.implication = implication;
        }
        public void setSolution(string solution)
        {
            this.solution = solution;
        }
        public void setAffectedComponents(List<SystemComponent> affectedComponents)
        {
            this.affectedComponents = affectedComponents;
        }

        public bool isEquals(Fault fault)
        {
            return this.name == fault.getName() && this.implication == fault.getimplication() && this.isEqualSystemComponentLists(fault.getAffectedComponents(), this.affectedComponents);
        }

        public bool isEqualSystemComponentLists(
          List<SystemComponent> list1,
          List<SystemComponent> list2)
        {
            if (list1 == null || list2 == null || list1.Count != list2.Count)
                return false;
            if (list1.Count == 0)
                return true;
            for (int index = 0; index < list1.Count; ++index)
            {
                if (list1[index].getName() != list2[index].getName())
                    return false;
            }
            return true;
        }

        public string toString()
        {
            return "שם התקלה: " + this.name + ",משמעויות: " + this.implication;
        }
    }
}
