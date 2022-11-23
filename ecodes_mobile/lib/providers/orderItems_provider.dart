import './base_provider.dart';
import '../model/orderItem.dart';



class OrderItemProvider extends BaseProvider<OrderItem>{
 OrderItemProvider():super("OrderItems"){

 }

  @override
  OrderItem fromJson(data){
    return OrderItem.fromJson(data);
  }

}