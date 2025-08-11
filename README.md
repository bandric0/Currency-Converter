# Currency Converter

A full-stack currency converter application with a Flutter mobile frontend and a .NET Core backend API that uses MongoDB for caching exchange rates and integrates with Fixer.io API for real-time currency data.

## Backend Setup

### Prerequisites

- .NET 8 SDK
- MongoDB (local installation or MongoDB Atlas)
- Fixer.io API key (free at https://fixer.io/)

### Configuration

1. **Get a Fixer.io API Key**
   - Go to https://fixer.io/ and sign up for a free account
   - Copy your API key

2. **Configure the application**
   - Copy `.env.example` to `.env` (if using environment variables)
   - **Option A: Use appsettings.json**
     ```json
     {
       "FixerApiSettings": {
         "ApiKey": "your_actual_api_key_here"
       }
     }
     ```
   - **Option B: Use environment variables**
     ```bash
     export FixerApiSettings__ApiKey="your_actual_api_key_here"
     ```

3. **Set up MongoDB**
   - **Local MongoDB**: Install and start MongoDB service
   - **MongoDB Atlas**: Update connection string in appsettings.json

### Running the Application

1. **Navigate to the API project**
   ```bash
   cd backend/CurrencyConverter.API
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the API**
   - API: `http://localhost:5124`
   - Swagger UI: `http://localhost:5124/swagger`

### API Endpoints

#### Convert Currency
- **POST** `/api/currencyconverter/convert`
- **Request body:**
  ```json
  {
    "fromCurrency": "USD",
    "toCurrency": "EUR",
    "amount": 100,
    "date": "2024-01-15"
  }
  ```
- **Response:**
  ```json
  {
    "fromCurrency": "USD",
    "toCurrency": "EUR",
    "originalAmount": 100,
    "convertedAmount": 92.34,
    "exchangeRate": 0.9234,
    "date": "2024-01-15T00:00:00"
  }
  ```

### Architecture

- **Backend**: .NET 8 Web API
- **Database**: MongoDB for caching exchange rates
- **External API**: Fixer.io for real-time exchange rates (free plan compatible)

### How It Works

1. The application first checks MongoDB for existing exchange rates
2. If not found, it fetches from Fixer.io API (handles free plan EUR-base limitation)
3. Rates are cached in MongoDB for future use
4. API is CORS-enabled for frontend integration

### Notes

- The free Fixer.io plan only allows EUR as base currency. The app automatically handles currency conversion calculations.
- Exchange rates are cached by currency pair and date to minimize API calls.

## Frontend Setup (Flutter Mobile App)

### Prerequisites

- Flutter SDK (3.0 or higher)
- Android Studio / Xcode (for mobile development)
- Android SDK / iOS development tools

### Installation

1. **Navigate to the frontend directory**
   ```bash
   cd frontend
   ```

2. **Install dependencies**
   ```bash
   flutter pub get
   ```

3. **Configure the API endpoint**
   - Update the API URL in `lib/services/currency_service.dart` to point to your backend
   - Default: `http://localhost:5124` (for local development)
   - For mobile device testing, use your computer's IP address instead of localhost

### Running the Application

1. **Run on Android Emulator/Device**
   ```bash
   flutter run
   ```

2. **Build APK for Android**
   ```bash
   flutter build apk
   ```

3. **Build for iOS** (Mac only)
   ```bash
   flutter build ios
   ```

### Features

- Clean and intuitive Material Design UI
- Real-time currency conversion
- Support for multiple currencies
- Swap currencies functionality
- Error handling and validation
- Responsive design for different screen sizes

## Project Structure

```
Currency-Converter/
├── backend/
│   └── CurrencyConverter.API/     # .NET Core Web API
│       ├── Controllers/           # API endpoints
│       ├── Models/               # Data models
│       ├── Services/             # Business logic
│       └── Settings/             # Configuration classes
├── frontend/
│   └── lib/
│       ├── main.dart            # App entry point
│       ├── screens/             # UI screens
│       ├── services/            # API integration
│       └── models/              # Data models
└── README.md

```

## Getting Started

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/Currency-Converter.git
   cd Currency-Converter
   ```

2. **Set up the backend** (follow Backend Setup section above)

3. **Set up the frontend** (follow Frontend Setup section above)

4. **Run both applications**
   - Start the backend API first
   - Then run the Flutter app

## Configuration

### Important: API Key Security

Before pushing to a public repository:
1. Replace the API key in `appsettings.json` with a placeholder
2. Use environment variables or a `.env` file for local development
3. Never commit real API keys to version control

### MongoDB Connection

- Local: `mongodb://localhost:27017`
- Atlas: Update with your connection string

## Technologies Used

- **Frontend**: Flutter, Dart, Material Design
- **Backend**: .NET 8, C#, ASP.NET Core Web API
- **Database**: MongoDB
- **External API**: Fixer.io
- **Tools**: Visual Studio Code, Android Studio

## License

This project is open source and available under the MIT License.