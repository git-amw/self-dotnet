int num;

void RefDemo(out int num) {
    num = 10;
    num++;
}

RefDemo(out num);


Console.WriteLine(num);