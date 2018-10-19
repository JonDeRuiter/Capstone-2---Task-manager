using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_List___Capstone_2
{
    class Task
    {
        //Variables
        private string memberName;
        private string briefDescription;
        private string dueDate;
        private bool doneNotDone;

        //Properties
        public string MemberName
        {
            get { return memberName; }
            set { memberName = value; }
        }
        public string BriefDescription
        {
            get { return briefDescription; }
            set { briefDescription = value; }
        }
        public string DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool DoneNotDone
        {
            get { return doneNotDone; }
            set { doneNotDone = value; }
        }
        
        //Constructors
        public Task(string memberName, string briefDescription, DateTime dateDue)
        {
            this.memberName = memberName;
            this.briefDescription = briefDescription;
            //Formats datetime to remove hours so that I don't have to format it everytime the object's dueDate is called
            
            this.dueDate = dateDue.ToString("MM/dd/yyyy");
            this.DoneNotDone = false;
        }

        //Methods

        //Could have a method to print each task info?

    }
}
