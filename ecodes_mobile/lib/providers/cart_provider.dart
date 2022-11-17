import 'package:collection/collection.dart';
import 'package:ecodes_mobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/product.dart';


class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      return;
    } else {
      cart.items.add(CartItem(product));
    }
    cart.PriceToPay += product.price!;
    cart.currencyId = product.productType?.currencyId;
    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items.removeWhere((item) => item.product.productId == product.productId);
    cart.PriceToPay -= product.price!;
    if(cart.PriceToPay < 0){
      cart.PriceToPay = 0;
    }
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.productId == product.productId);
    return item;
  }
}