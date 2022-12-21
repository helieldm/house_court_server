namespace HouseCourt.Helper;

public static class MessageHelper
{
    // Separator used in the messages
    public const String Separator = ";";
    public const String Begin = "BEGIN";
    public const String End = "END";

    // Message to register a house, sent at every startup
    public const String Register = "REGISTER";
    
    // Indicates a temp and humidity reading message
    public const String DhtData = "DHT";
    
    public const String Door = "DOOR";
    public const String Window = "WINDOW";
    public const String Vents = "VENTS";
    public const String ON = "ON";
    public const String OFF = "OFF";
    
    
}