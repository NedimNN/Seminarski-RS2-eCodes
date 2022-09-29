import 'package:ecodes_mobile/model/currency.dart';
import 'package:ecodes_mobile/model/wallet.dart';
import 'package:ecodes_mobile/providers/cart_provider.dart';
import 'package:ecodes_mobile/providers/currency_provider.dart';
import 'package:ecodes_mobile/providers/wallet_provider.dart';
import 'package:ecodes_mobile/widgets/master_bottom_drawer.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

class WalletScreen extends StatefulWidget {
  String Id;
  WalletScreen(this.Id, {Key? key}) : super(key: key);

  @override
  State<WalletScreen> createState() => _WalletScreenState();
}

class _WalletScreenState extends State<WalletScreen> {
  WalletProvider? _walletProvider = null;
  CurrencyProvider? _currencyProvider = null;
  Wallet _wallet = new Wallet();
  Currency _currency = new Currency();

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _walletProvider = context.watch<WalletProvider>();
    _currencyProvider = context.watch<CurrencyProvider>();
  }

  void loadWallet() async {
    var searchRequest = {'buyerId': int.parse(widget.Id)};
    var tmpWallet = await _walletProvider?.get(searchRequest);
    var currency = await _currencyProvider?.getById(tmpWallet!.first.currencyId!);
    setState(() {
      _wallet = tmpWallet!.first;
      _currency = currency!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterWidget(
      selectedIndex: 3,
      child: SingleChildScrollView(
        child: Column(
          children: [
            _buildWalletHeader(),
            _buildWallet(),
          ],
        ),
      ),
    );
  }

  Widget _buildWalletHeader() {
    // if (_wallet == null) {
    //   return Container(
    //     padding: EdgeInsets.only(left: 25),
    //     child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
    //   );
    // }

    return Container(
      width: MediaQuery.of(context).size.width,
      child: Column(children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(
              height: 75,
              width: 75,
              child: Container(
                  child: Icon(size: 55, Icons.account_balance_wallet_outlined)),
            ),
            SizedBox(
              height: 75,
              width: 250,
              child: Center(
                child: Text(
                    style: Theme.of(context).textTheme.bodyText2,
                    "Total balance: ${_wallet.balance} ${_currency.abbreviation}"),
              ),
            )
          ],
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            SizedBox(
              width: 125,
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      // Take user to add funds screen
                    },
                    child: Icon(size: 55, Icons.add_circle_outline),
                  ),
                  Center(child: Text("Add funds")),
                ],
              ),
            ),
            SizedBox(
              width: 55,
            ),
            SizedBox(
              width: 175,
              child: Column(
                children: [
                  InkWell(
                    onTap: () {
                      // Take user to change currency screen
                    },
                    child: Icon(size: 55, Icons.currency_exchange_rounded),
                  ),
                  Center(
                    child: Text("Change currency"),
                  ),
                ],
              ),
            )
          ],
        )
      ]),
    );
  }
  Widget _buildWallet() {
    //     if (_currency == null) {
    //   return Container(
    //     padding: EdgeInsets.only(left: 25),
    //     child: Text(style: Theme.of(context).textTheme.headline6, "Loading..."),
    //   );
    // }



    return Container(

      //Add funds and change currency forms here
    );

  }
}
