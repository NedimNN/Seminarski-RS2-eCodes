import './product.dart';

class Cart {
    List<CartItem> items = [];
    double PriceToPay = 0;
    int? currencyId = 1;
}

class CartItem {
  CartItem(this.product);
  late Product product;
}