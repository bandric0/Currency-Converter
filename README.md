# Currency Converter

A currency converter application with a .NET Core backend API that uses MongoDB for caching exchange rates and integrates with Fixer.io API for real-time currency data.

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