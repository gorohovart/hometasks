namespace Regexp
open System.Text.RegularExpressions

type public UserInputChecker() = 
    static member public IsZip zip = 
        let USARegex = new Regex(@"^([\d]){6}$");
        let RusRegex = new Regex(@"^([\d]){5}[-]([\d]){4}$");
        USARegex.IsMatch(zip) || RusRegex.IsMatch(zip)

    static member public IsPhoneNumber phone = 
        let phoneRegex = new Regex(@"^((\+7|8)( )?(\()?([\d]){3}(\))?( )?)?([\d]){3}(-| )?([\d]){2}(-| )?([\d]){2}$");
        phoneRegex.IsMatch(phone)

    static member public IsEmergencyPhoneNumber phone = 
        let emPhoneRegex = new Regex(@"^((01|02|03|04)(0)?|(9)?(01|02|03|04))$");
        emPhoneRegex.IsMatch(phone)

    static member public IsEmail email = 
        let emailRegex = new Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        emailRegex.IsMatch(email)
