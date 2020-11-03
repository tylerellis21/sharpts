namespace WP.Models {

    public interface UserInterface {
        int Id { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
    }
    
    public class BaseClassTest {
        public string BaseClassValue { get; set; }
    }

    public class Employee : BaseClassTest, UserInterface  {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Hitler { get; set; }
    }
}