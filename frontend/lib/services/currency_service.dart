import 'dart:convert';
import 'package:http/http.dart' as http;
import '../config/app_config.dart';

class CurrencyService {
  static String get baseUrl => AppConfig.apiBaseUrl;

  Future<double> convertCurrency({
    required double amount,
    required String fromCurrency,
    required String toCurrency,
    required DateTime date,
  }) async {
    try {
      final requestBody = {
        'fromCurrency': fromCurrency,
        'toCurrency': toCurrency,
        'amount': amount,
        'date': date.toIso8601String(),
      };
      
      final response = await http.post(
        Uri.parse('$baseUrl/CurrencyConverter/convert'),
        headers: {
          'Content-Type': 'application/json',
        },
        body: json.encode(requestBody),
      );

      if (response.statusCode == 200) {
        final data = json.decode(response.body);
        return data['convertedAmount'].toDouble();
      } else {
        throw Exception('Failed to convert currency: ${response.statusCode}');
      }
    } catch (e) {
      throw Exception('Error connecting to backend: $e');
    }
  }
}