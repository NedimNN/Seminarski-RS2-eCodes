import '../model/seller.dart';
import 'base_provider.dart';

class SellerProvider extends BaseProvider<Seller> {
  SellerProvider() : super("Sellers");

  @override
  Seller fromJson(data) {
    return Seller.fromJson(data);
  }
}
