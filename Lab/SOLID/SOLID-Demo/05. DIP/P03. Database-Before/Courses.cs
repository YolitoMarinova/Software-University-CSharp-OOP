namespace P03._Database
{
    public class Courses
    {
        private Data data { get; set; }

        public Courses(Data data)
        {
            this.data = data;
        }
        public void PrintAll()
        {
            var courses = data.CourseNames();

            //print courses
        }

        public void PrintIds()
        {
            var courseIds = data.CourseIds();

            //print course ids
        }

        public void PrintById(int id)
        {
            var course = data.GetCourseById(id);

            // print course
        }

        public void Search(string substring)
        {
            var courses = data.Search(substring);

            // print courses
        }
    }
}
