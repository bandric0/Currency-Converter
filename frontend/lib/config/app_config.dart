/// Application configuration
/// 
/// To configure for your environment:
/// 1. For Android Emulator: Use 10.0.2.2 instead of localhost
/// 2. For Physical Device: Use your computer's IP address
/// 3. For iOS Simulator: localhost works fine
/// 4. For Production: Use your actual API domain
class AppConfig {
  // Default to localhost for development
  // Change this to your backend API URL
  static const String apiBaseUrl = 'http://localhost:5124/api';
  
  // For Android emulator, uncomment this line:
  // static const String apiBaseUrl = 'http://10.0.2.2:5124/api';
  
  // For physical device testing, use your computer's IP:
  // static const String apiBaseUrl = 'http://YOUR_COMPUTER_IP:5124/api';
  
  // For production, use your actual API endpoint:
  // static const String apiBaseUrl = 'https://your-api-domain.com/api';
}