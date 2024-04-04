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
        public Teacher AdminTeacher { get; set; }
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
                UserId = "228dfc0a-78a8-4163-aff3-94a5c1014fbb",
                FirstName = "Ani",
                LastName = "Ivanova",
                Amount = 180
                    

            };

            Parent anotherParent = new Parent()
            {
                Id = 2,
                UserId = "03d74db7-55ee-4ee0-ae1d-7c16a4578141",
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
                UserId = "a05289cd-5411-45bb-b863-ba2394c21342",
                FirstName = "Snezhana",
                LastName = "Ilieva",
                
               
            };
            Teacher = teacher;

            Teacher adminTeacher = new Teacher()
            {
                Id = 3,
                UserId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92",
                FirstName = "Petia",
                LastName = "Petrova",

			};

            AdminTeacher = adminTeacher;
        }

        private void SeedAdmin()
        {
            Admin admin = new Admin()
            {
                Id = 1,
                UserId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92",
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
                CreatedOn = new DateTime(2024 ,04 , 03, 13, 52, 21),

            };

            ProblemWithToni = theme;
        }

        private void SeedPosts()
        {
            Post contentForToni = new Post()
            {
                Id = 1,
                Content = "Hello i want to write Toni has problem with food . Do you have this problem ?",
                CreatedOn = new DateTime(2024, 04 , 03, 13, 52,21),
                CreatorId = Parent.UserId,
                ThemeId = ProblemWithToni.Id,
              
            };

            Post answerForToni = new Post()
            {
                Id = 2,
                Content = "I have the same problem",
                CreatedOn = new DateTime(2024, 04, 03, 13, 52, 21),
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
                CreatedOn = new DateTime(2024, 04, 03, 13, 52, 21),
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
                DeadTime =new DateTime(2024, 04, 03, 13,52,21),
                Description = "This year the present of the teacher will be two boxes of flowers",
                NeededAmount = 80,
                AmountForPay = 5
            };

            Christmas = gift;
        }

    }
}
