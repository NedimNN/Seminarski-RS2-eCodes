
import 'package:ecodes_mobile/providers/base_provider.dart';
import 'package:ecodes_mobile/model/order.dart';



class OrderProvider extends BaseProvider<Order>{
 OrderProvider():super("Orders"){

 }

  @override
  Order fromJson(data){
    return Order.fromJson(data);
  }

  // removeOrder(Order order) {
  //   if (findOrder(product)!.count > 1) {
  //     removeWhere((item) => item.product.productId == product.productId)
  //   }
  //   notifyListeners();
  // }

  // CartItem? findOrder(Product product) {
  //   CartItem? item = cart.items.firstWhereOrNull((item) => item.product.productId == product.productId);
  //   return item;
  // }

}