using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //int count = 0;
            List<TaskToDo> tasks = new List<TaskToDo>() { };
            List<TaskReminder> taskRem = new List<TaskReminder>() { };

            // creating tasks:
            TaskToDo task1 = new TaskToDo ( 1,"task1","do cleaning" );
            TaskToDo task2 = new TaskToDo (2, "task2", "do washing" );
            TaskToDo task3 = new TaskToDo(3, "task3", "do coding");
            TaskReminder taskRem1 = new TaskReminder (4,"task4", "do math " , new DateTime(2020, 9, 20));
            TaskReminder taskRem2 = new TaskReminder(5,"task5", "do programming", new DateTime(2020, 7, 30));
            TaskReminder taskRem3 = new TaskReminder(6, "task6", "do english", new DateTime(2020, 3, 30));
            TaskReminder taskRem4 = new TaskReminder(7, "task7", "do course work", new DateTime(2020, 3, 30));
            TaskReminder taskRem5 = new TaskReminder(8, "task8", "do diploma", new DateTime(2020, 4, 10));


            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            taskRem.Add(taskRem1);
            taskRem.Add(taskRem2);
            taskRem.Add(taskRem3);
            taskRem.Add(taskRem4);
            taskRem.Add(taskRem5);

            // deleting tasks:
            //tasks.Remove(task1);


            //editing tasks:
            task1.Edit("new task1", "new things to do");
            taskRem1.Edit("new task4", "do algebra",new DateTime(2020, 3, 31));
           
            // reminding tasks for today
            foreach (TaskReminder t in taskRem)
            {

                if (t.Date == DateTime.Today)
                {

                    Console.WriteLine($"!!!\t\t {t.Count}. Name of task:\t {t.Name}\t  Description: {t.Descrip} \t\tmust be done today!");
                }

            }


            Console.WriteLine("\n\nAll Tasks:");
            foreach (TaskToDo t in tasks)

            {
                Console.WriteLine($" {t.Count}. Name of task:\t {t.Name}\t  Description: {t.Descrip}");
            }



            foreach (TaskReminder t in taskRem)

            {
                Console.WriteLine($" {t.Count}. Name of task:\t {t.Name}\t  Description: {t.Descrip}\t Date: {t.Date}");
            }

            //noting tasks as done
            task1.Done(true);
            task2.Done(false);
            
            //recording to file
            string path = @"D:\4_COURSE\SET\TaskManager\TaskManager\tasks.txt";
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("All tasks:");
                foreach (TaskToDo t in tasks)
                {
                    sw.Write(t.Count); sw.Write('\t');
                    sw.Write(t.Name); sw.Write('\t');
                    sw.WriteLine(t.Descrip);
                }
                foreach (TaskReminder t in taskRem)
                {
                    sw.Write(t.Count); sw.Write('\t');
                    sw.Write(t.Name); sw.Write('\t');
                    sw.Write(t.Descrip); sw.Write('\t');
                    sw.WriteLine(t.Date);
                }
                Console.WriteLine("Recording to file is completed ");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
          
        
            Console.ReadKey();

        }
        

    }

    

    class TaskToDo
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public string Descrip { get; set; }

        public TaskToDo(int count,string name,string descrip)
        {
            Count = count;
            Name = name;
            Descrip = descrip;
        }

        public void Edit(string newName,string newDescrip)
        {
            Name = newName;
            Descrip = newDescrip;
        }

        public void Done(bool flag)
        {

            if (flag == true) Console.WriteLine($"Task №{Count} is already done");
        }
        
    }

    class TaskReminder : TaskToDo
    {
        public DateTime Date { get; set; }
        public TaskReminder(int count,string name, string descrip,DateTime date):base(count,name,descrip)
        {
            Date = date;
        }

        public void Edit(string newName, string newDescrip,DateTime newDate)
        {
            Name = newName;
            Descrip = newDescrip;
            Date = newDate;
        }

    }

    
}
