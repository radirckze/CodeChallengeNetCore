using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge {

    //Source: http://practice.geeksforgeeks.org/problems/job-sequencing-problem/0

    //Simple 3 step process. First sort by ascending deadline and desending PRofit.
    //Second, identify jobs that can / cannot be ssheduled. Third, optimize for profit.

    public class Job : IComparable  {
        public int Id;
        public int Deadline;
        public int Profit;
        public bool Scheduled = false;

        public Job(int id, int deadline, int profit) {
            this.Id = id;
            this.Deadline = deadline;
            this.Profit = profit;
        }

        //Compares first by deadline (increasing), then by profit (decreasing).
        public int CompareTo(object other) {
            if (other == null) {
                return 1;
            }
            else if (other.GetType() != typeof(Job) )  {
                throw new ArgumentException();
            }

            Job OtherJob = (Job)other;

            if (this.Deadline != OtherJob.Deadline) {
                return this.Deadline - OtherJob.Deadline;
            }
            else {
                return -(this.Profit - OtherJob.Profit);
            }

        } 
    }

    // sort, schedule, then optimize.
    public class JobSequencing {

        public int SequenceJobs(List<Job> jobs) {
            if (jobs == null || jobs.Count < 1) {
                return 0;
            }

            int totalProfit = 0;

            //first sort it by deadline (secondary by decreasing profit)
            jobs.Sort();

            // determined whether each job can be scheduled.
            int lastTaken = 0;
            int currSlot = 1;
            foreach(Job job in jobs) {
                if(job.Deadline <= currSlot && job.Deadline > lastTaken) {
                    job.Scheduled = true;
                    lastTaken +=1;
                }
                currSlot++;
            }

            //Optimize for optimal profitability. That is, if a job is not 
            //scheduled, then check prior jobs and swap it increases profit.
            for(int i=0; i<jobs.Count; i++) {
                if (!jobs[i].Scheduled) {
                    int smallestUnscheduled = -1;
                    for(int j=0; j<i-1; j++) {
                        if (jobs[j].Scheduled && jobs[j].Profit < jobs[i].Profit) {
                            if (smallestUnscheduled == -1) {
                                smallestUnscheduled = j;
                            }
                            else if (jobs[smallestUnscheduled].Profit > jobs[j].Profit) {
                                smallestUnscheduled = j;
                            }
                        } 
                    }

                    if (smallestUnscheduled != -1) {
                        jobs[smallestUnscheduled].Scheduled = false;
                        jobs[i].Scheduled = true;
                    }
                }
            }

            //Calculate profit. 
            foreach(Job job in jobs) {
                if (job.Scheduled) {
                    totalProfit += job.Profit;
                }
            }

            return totalProfit; 
        }  

        public void TestJobSequencing() {

            List<Job> jobs = null;
            int result = this.SequenceJobs(jobs);
            Console.WriteLine("Status of null list check: {0}", result==0);

            //first test case from site
            jobs = new List<Job>() {new Job(1,4,20), new Job(2,1,10), 
                new Job(3,1,40), new Job(4,1,30) };
            result = this.SequenceJobs(jobs);
            Console.WriteLine("Status of  first test: {0}", result==60);

            //second test case from site.
            jobs = new List<Job>() {new Job(1,2,100), new Job(2,1,19), 
                new Job(3,2,27), new Job(4,1,25), new Job(5,1,15) };
            result = this.SequenceJobs(jobs);
            Console.WriteLine("Status of second test: {0}", result==127);

        } 
        
    }
}