import './base_provider.dart';

import '../model/currency.dart';

class CurrencyProvider extends BaseProvider<Currency>{
  CurrencyProvider():super("Currency"){

  }

@override
  Currency fromJson(data) {
    // TODO: implement fromJson
    return Currency.fromJson(data);
  }

}