//
//  UnityBridge.cpp
//  Spajam2
//
//  Created by 繁田竣 on 2018/05/28.
//  Copyright © 2018 繁田竣. All rights reserved.
//

#include "UnityBridge.hpp"
#include "Spajam2.h"

int addTen()
{
    NSLog(@"addTen method is invoked.");
    int num = 10;
    return [Spajam2 calc:num];
}


int subTen(){
    NSLog(@"subTen method is invoked.");
    int num = -10;
    return [Spajam2 calc:num];
}
