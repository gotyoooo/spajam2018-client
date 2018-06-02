//
//  Spajam2.m
//  Spajam2
//
//  Created by 繁田竣 on 2018/05/28.
//  Copyright © 2018 繁田竣. All rights reserved.
//

#import "Spajam2.h"

@implementation Spajam2

int num = 0;

+ (int)calc:(int)_num{
    num += _num;
    NSLog(@"result: %d", num);
    return num;
}

// 参考→ https://qiita.com/shell/items/7a1e585f030f3f6aa601
@end
