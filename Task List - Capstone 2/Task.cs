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
        private DateTime dueDate;
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
        public DateTime DueDate
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
        public Task(string memberName, string briefDescription, DateTime dueDate)
        {
            this.memberName = memberName;
            this.briefDescription = briefDescription;
            this.dueDate = dueDate;
            this.DoneNotDone = false;
        }

        //Methods



    }
}
