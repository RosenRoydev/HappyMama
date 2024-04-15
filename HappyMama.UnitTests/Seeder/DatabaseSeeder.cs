using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;

namespace HappyMama.UnitTests.NewFolder
{
    public static  class DatabaseSeeder
    {
        public static IdentityUser UserA;
        public static IdentityUser UserB;
        public static IdentityUser UserC;
        public static IdentityUser UserD;
        public static Admin AdminUser;
        public static Teacher Teacher;
        public static Parent Parent;
        public static Parent ParentTwo;
        public static Post Post;
        public static Theme Theme;
        public static Post AnotherPost;
        public static Event SomeEvent;
            
        public static void SeedDatabase(HappyMamaDbContext db)
        {
            //admin
            UserA = new IdentityUser()
            {
                UserName = "admin@abv.bg",
                NormalizedUserName = "ADMIN@ABV.BG",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEOHaWO4rZrw6GrPlPpj54QHzxFk55zwd+dNPS5kadZ9mJAHBj8N1nVJr/H3h6pr71g==",
                ConcurrencyStamp = "afe68dd4-b601-46e2-8add-615ccf88ea73",
                SecurityStamp = "7HADFPDLYMHWBAOX7HBJFCU6HYRJ4S6K",
                TwoFactorEnabled = false,
                LockoutEnabled = true
               
            };

            //teacher
            UserB = new IdentityUser()
            {
                UserName = "teacher@abv.bg",
                NormalizedUserName = "TEACHER@ABV.BG",
                Email = "teacher@abv.bg",
                NormalizedEmail = "TEACHER@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEGwHa/75nidFV1zx5NwA6oZyqLWuAPtWS7wRcA+uqwidDNAn4y2a7A/g8U0I2aga+Q==",
                ConcurrencyStamp = "ac26ade8-986a-4e8d-a48f-74025280c00e",
                SecurityStamp = "OVP3K5BRCFV3XLSODYBEKIMDSJH5GLEM",
                TwoFactorEnabled = false,
                LockoutEnabled = true

            };

            //parent
            UserC = new IdentityUser()
            {
                UserName = "parent@abv.bg",
                NormalizedUserName = "PARENT@ABV.BG",
                Email = "parent@abv.bg",
                NormalizedEmail = "PARENT@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEAEzEPeRZt4VNVoul47qv92r3azc7W8pDWHstTxJc1KWwMrq64TAOUydw9LkB/6eGw==",
                ConcurrencyStamp = "a8595609-b374-4d6d-9c33-f806cc43768f",
                SecurityStamp = "R233HXN4COG5A7ZE4JM3P5JBKQCQLOI3",
                TwoFactorEnabled = false,
                LockoutEnabled = true

            };

            //anotherParent
            UserD = new IdentityUser()
            {
                UserName = "parentTwo@gmail.com",
                NormalizedUserName = "PARENTTWO@GMAIL.COM",
                Email = "parentTwo@gmail.com",
                NormalizedEmail = "PARENTTWO@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEGUPcHRxubshL/QcA0bqen8uqLRKiULZ1I3CJX5+Rxbr4L8aUZ+JStmwtGZ7dtcetg==",
                ConcurrencyStamp = "01de6e9c-bed7-4411-9228-cacf3ad32fc8",
                SecurityStamp = "MY2ZBCUAEOUYDJNYG4KLARXIIUVJWYB6",
                TwoFactorEnabled = false,
                LockoutEnabled = true

            };

            Parent = new Parent()
            {
               
                UserId = "228dfc0a-78a8-4163-aff3-94a5c1014fbb",
                FirstName = "Ioana",
                LastName = "Strahilova",
                Amount = 180


            };

            ParentTwo = new Parent()
            {
                
                UserId = "03d74db7-55ee-4ee0-ae1d-7c16a4578141",
                FirstName = "Neli",
                LastName = "Petrova",
                Amount = 180
            };

            AdminUser = new Admin()
            {
              
                UserId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92",
                Nickname = "dimova",
            };

            Teacher = new Teacher()
            {
                
                UserId = "a05289cd-5411-45bb-b863-ba2394c21342",
                FirstName = "Vasil",
                LastName = "Manov",
            };

            Theme = new Theme()
            {
               
                CreatorId = Parent.UserId,
                Title = "I am very happy with teachers staff",
                CreatedOn = new DateTime(2024, 04, 03, 13, 52, 21),
            };

            Post = new Post()
            {
                
                Content = " The teachers are perfect . What do you think?",
                CreatedOn = new DateTime(2024, 04, 03, 13, 52, 21),
                CreatorId = Parent.UserId,
                ThemeId = Theme.Id,
            };

            AnotherPost = new Post()
            {
                Content = "I think so too",
                CreatedOn = new DateTime(2024, 04, 03, 13, 52, 21),
                CreatorId = ParentTwo.UserId,
                ThemeId = Theme.Id,
            };

            SomeEvent = new Event()
            {
             
                Name = "Easter gifts for the teachers",
                CreatorId = AdminUser.UserId,
                DeadTime = new DateTime(2024, 04, 03, 13, 52, 21),
                Description = "This year the present of the teacher will be two boxes of flowers",
                NeededAmount = 100,
                AmountForPay = 10
            };

            db.Users.Add(UserA);
            db.Users.Add(UserB);
            db.Users.Add(UserC);
            db.Users.Add(UserD);
            db.Admins.Add(AdminUser);
            db.Teachers.Add(Teacher);
            db.Parents.Add(Parent);
            db.Parents.Add(ParentTwo);
            db.Themes.Add(Theme);
            db.Posts.Add(Post);
            db.Posts.Add(AnotherPost);
            db.Events.Add(SomeEvent);

            db.SaveChanges();
        }
     
    }
}
