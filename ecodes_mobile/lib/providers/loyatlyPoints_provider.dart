import './base_provider.dart';

import '../model/loyaltyPoints.dart';

class LoyaltyPointsProvider extends BaseProvider<LoyaltyPoints>{
  LoyaltyPointsProvider():super("LoyaltyPoints"){

  }

@override
  LoyaltyPoints fromJson(data) {
    // TODO: implement fromJson
    return LoyaltyPoints.fromJson(data);
  }

}