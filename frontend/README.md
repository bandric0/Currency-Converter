# Currency Converter - Flutter Frontend

A Flutter mobile application for currency conversion with a clean Material Design interface.

## Configuration

### API Endpoint Setup

Before running the app, configure the API endpoint in `lib/config/app_config.dart`:

```dart
// For different environments, update the apiBaseUrl:

// Development (localhost)
static const String apiBaseUrl = 'http://localhost:5124/api';

// Android Emulator
static const String apiBaseUrl = 'http://10.0.2.2:5124/api';

// Physical Device (use your computer's IP)
static const String apiBaseUrl = 'http://YOUR_COMPUTER_IP:5124/api';

// Production
static const String apiBaseUrl = 'https://your-api-domain.com/api';
```

### How to Find Your Computer's IP Address

**Windows:**
```bash
ipconfig
# Look for IPv4 Address
```

**Linux/Mac:**
```bash
ifconfig
# or
ip addr show
```

## Prerequisites

- Flutter SDK (3.0+)
- Dart SDK
- Android Studio / Xcode (for mobile development)
- Running backend API (see backend README)

## Installation

1. Install dependencies:
   ```bash
   flutter pub get
   ```

2. Configure the API endpoint (see Configuration section above)

3. Ensure the backend API is running

## Running the App

### Android Emulator
```bash
flutter run
```

### iOS Simulator (Mac only)
```bash
flutter run
```

### Physical Device
1. Enable Developer Mode on your device
2. Connect via USB
3. Run:
   ```bash
   flutter run
   ```

## Building for Release

### Android APK
```bash
flutter build apk --release
```

### Android App Bundle
```bash
flutter build appbundle --release
```

### iOS (Mac only)
```bash
flutter build ios --release
```

## Features

- Real-time currency conversion
- Support for 160+ currencies
- Material Design UI
- Currency swap functionality
- Input validation
- Error handling
- Responsive design

## Project Structure

```
lib/
├── main.dart              # App entry point
├── config/
│   └── app_config.dart   # Configuration settings
├── screens/
│   └── currency_converter_screen.dart  # Main UI screen
├── services/
│   └── currency_service.dart  # API communication
└── models/               # Data models (if any)
```

## Troubleshooting

### Connection Issues

1. **"Connection refused" error**
   - Ensure backend API is running
   - Check API URL configuration in `app_config.dart`
   - For Android emulator, use `10.0.2.2` instead of `localhost`

2. **Network permission issues on Android**
   - Already configured in `AndroidManifest.xml`
   - `android:usesCleartextTraffic="true"` allows HTTP in development

3. **CORS issues**
   - Backend should have CORS enabled
   - Check backend configuration

### Build Issues

1. **Gradle version errors**
   - Update `android/gradle/wrapper/gradle-wrapper.properties`
   - Use Gradle 8.4 or higher

2. **SDK version conflicts**
   - Check `android/app/build.gradle` for minSdkVersion
   - Ensure Flutter SDK is up to date

## Development Tips

- Use Flutter DevTools for debugging: `flutter pub global activate devtools`
- Hot reload with `r` in terminal while running
- Hot restart with `R` for state changes
- Run `flutter doctor` to check your environment setup

## License

This project is part of the Currency Converter application. See main README for license information.