
import 'package:ecodes_mobile/providers/base_provider.dart';
import 'package:ecodes_mobile/model/order.dart';



class OrderProvider extends BaseProvider<Order>{
 OrderProvider():super("Orders"){

 }

  @override
  Order fromJson(data){
    return Order.fromJson(data);
  }

}