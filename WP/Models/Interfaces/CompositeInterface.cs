namespace WP.Models {

    public interface CompositeInterface : 
        BaseInterface, TestInterface {
    
        string CompositeName { get; set; }
    }
} 