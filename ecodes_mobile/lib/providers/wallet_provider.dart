import 'package:ecodes_mobile/providers/base_provider.dart';

import '../model/wallet.dart';

class WalletProvider extends BaseProvider<Wallet>{
  WalletProvider():super("Wallet"){

  }

@override
  Wallet fromJson(data) {
    // TODO: implement fromJson
    return Wallet.fromJson(data);
  }

}