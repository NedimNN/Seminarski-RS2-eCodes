import 'package:ecodes_mobile/providers/base_provider.dart';

import '../model/payment.dart';

class PaymentProvider extends BaseProvider<Payment>{
  PaymentProvider():super("Payment"){

  }

@override
  Payment fromJson(data) {
    // TODO: implement fromJson
    return Payment.fromJson(data);
  }

}