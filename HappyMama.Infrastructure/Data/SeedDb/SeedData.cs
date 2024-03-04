using HappyMama.Infrastructure.Data.DataModels;

namespace HappyMama.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public Event Christmas { get; set; }
        public News Vaccine { get; set; }
        public Theme ProblemWithToni {  get; set; }
        public Post ContentForToni { get; set; }
        public Post AnswerForToni { get; set; }
        public Admin Admin {  get; set; }
        public Teacher Teacher { get; set; }
        public Parent Parent { get; set; }
        public Parent AnotherParent { get; set; }

        public SeedData()
        {
           
            SeedAdmin();
            SeedTeacher();
            SeedParent();
            SeedEvent();
            SeedNews();
            SeedTheme();
            SeedPosts();
           

        }

        private void SeedParent()
        {
            Parent parent = new Parent()
            {
                Id = 1,
                UserId = "d2a09f19-256f-47ce-b661-04fe9fb105d6",
                FirstName = "Ani",
                LastName = "Ivanova",
                Amount = 180
                    

            };

            Parent anotherParent = new Parent()
            {
                Id = 2,
                UserId = "de119094-95c7-4b8f-a4be-e46203394b69",
                FirstName = "Petia",
                LastName = "Dubarova",
                Amount = 180
            };

            AnotherParent = anotherParent;
            Parent = parent;
        }

        private void SeedTeacher()
        {
            Teacher teacher = new Teacher()
            {
                Id = 1,
                UserId = "8b6afc3a-0922-497a-b97d-faf99cb5b2ff",
                FirstName = "Snezhana",
                LastName = "Ilieva",
                
               
            };
            Teacher = teacher;
        }

        private void SeedAdmin()
        {
            Admin admin = new Admin()
            {
                Id = 1,
                UserId = "90402621-705a-4592-9195-70a26d1188cc",
                Nickname = "petrova",

            };
            Admin = admin;
        }

        private void SeedTheme()
        {
            Theme theme = new Theme()
            {
                Id = 1,
                CreatorId = Parent.UserId,
                Title = "Problem with Toni",
                CreatedOn = DateTime.UtcNow,

            };

            ProblemWithToni = theme;
        }

        private void SeedPosts()
        {
            Post contentForToni = new Post()
            {
                Id = 1,
                Content = "Hello i want to write Toni has problem with food . Do you have this problem ?",
                CreatedOn = DateTime.UtcNow,
                CreatorId = Parent.UserId,
                ThemeId = ProblemWithToni.Id,
              
            };

            Post answerForToni = new Post()
            {
                Id = 2,
                Content = "I have the same problem",
                CreatedOn = DateTime.UtcNow,
                CreatorId = AnotherParent.UserId,
                ThemeId = ProblemWithToni.Id,
            };

            ContentForToni = contentForToni;
            AnswerForToni = answerForToni;
        }

        private  void SeedNews()
        {
            News news = new News()
            {
                Id = 1,
                Title = "Vaccine against Flu",
                CreatedOn = DateTime.UtcNow,
                Description = "All parents , who want their child to be vaccinated , please contact with me ." +
                " The vaccination is organized by the Ministry of health and is for free!",
                CreatorId = Teacher.UserId,


            };

            Vaccine = news;
        }

        private void SeedEvent()
        {
            Event gift = new Event()
            {
                Id = 1,
                Name = "Christmas gifts for the teachers",
                CreatorId = Admin.UserId,
                DeadTime = DateTime.UtcNow,
                Description = "This year the present of the teacher will be two boxes of flowers",
                NeededAmount = 80,
            };

            Christmas = gift;
        }

    }
}
