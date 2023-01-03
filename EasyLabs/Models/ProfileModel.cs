namespace EasyLabs.Models
{
    public class ProfileModel
    {
        public string name { get; set; }
        public string phone_number { get; set; }
        public string mail { get; set; }
        public string gender { get; set; }

        public ProfileModel(string name, string phone_number, string mail, string gender)
        {
            this.name = name;
            this.phone_number = phone_number;
            this.mail = mail;
            this.gender = gender;
        }
        public static ProfileModel PTransform(UserModel um)
        {
            ProfileModel pm = new ProfileModel(um.name, um.phone_number, um.mail, um.gender);
            return pm;
        }
        public static ProfileModel PLTransform(DataLibrary.Models.ProfileModel um)
        {
            ProfileModel pm = new ProfileModel(um.name, um.phone_number, um.mail, um.gender);
            return pm;
        }
    }
}
