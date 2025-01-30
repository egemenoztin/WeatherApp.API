# WeatherApp.API

## Overview

WeatherApp.API is a backend service built with ASP.NET Core that provides real-time weather data and forecasts. It integrates with external weather APIs to deliver accurate and up-to-date weather information.

## Features

- **Current Weather Data**: Fetches real-time weather details for a given location.
- **Weather Forecast**: Provides weather forecasts for multiple days.
- **Scalable Architecture**: Designed for efficient handling of multiple API requests.
- **Multiple Data Sources**: Supports integration with various weather providers.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/) with the C# extension
- API key from a weather data provider (e.g., OpenWeatherMap)

### Installation

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/egemenoztin/WeatherApp.API.git
   cd WeatherApp.API
   ```

2. **Configure API Key**:

   - Open `appsettings.json`.
   - Add your API key:
     ```json
     {
       "Logging": {
         "LogLevel": {
           "Default": "Information",
           "Microsoft.AspNetCore": "Warning"
         }
       },
       "AllowedHosts": "*",
       "ApiKey": "YOUR_API_KEY"
     }
     ```

3. **Restore Dependencies**:

   ```bash
   dotnet restore
   ```

4. **Build the Project**:

   ```bash
   dotnet build
   ```

5. **Run the Application**:

   ```bash
   dotnet run
   ```

   The API will be available at `https://localhost:7171` by default.

## Usage

Access the Swagger UI for interactive API documentation:

```
https://localhost:7171/swagger
```

### Endpoints

#### Weather

- **GET** `/api/Weather/getWeatherData?city={city}&unit={unit}`  Get the current weather data.
- **POST** `/api/Weather/setTemperatureUnit?unit={unit}` Set the temperature unit (e.g., Celsius, Fahrenheit).

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.

2. Create a new branch:

   ```bash
   git checkout -b feature/YourFeatureName
   ```

3. Make your changes and commit them:

   ```bash
   git commit -m "Add some feature"
   ```

4. Push the branch:

   ```bash
   git push origin feature/YourFeatureName
   ```

5. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [OpenWeatherMap](https://openweathermap.org/)



