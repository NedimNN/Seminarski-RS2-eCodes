import 'package:ecodes_mobile/providers/base_provider.dart';
import 'package:ecodes_mobile/model/orderItem.dart';



class OrderItemProvider extends BaseProvider<OrderItem>{
 OrderItemProvider():super("OrderItems"){

 }

  @override
  OrderItem fromJson(data){
    return OrderItem.fromJson(data);
  }

}