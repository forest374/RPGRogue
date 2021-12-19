using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

    public enum LineAge
    {
        Bug,
        Slime,
        Ogre,
        Beast,
        Bird,
        Devil,
        Fish,
        Machine
    }

// https://qiita.com/okk_archives/items/fd45e579d0bcc2bc889b
// https://docs.microsoft.com/ja-jp/dotnet/api/system.linq.enumerable.singleordefault?view=netframework-4.8
public class EnemyID
{
    // スキル一覧
    static readonly IDBase[] enemyID = {
        new Bug(),
        new Slime(),
        new Ogre(),
        new Beast(),
        new Bird(),
        new Devil(),
        new Fish(),
        new Machine()
    };

    public IDBase Create(LineAge lineAge)
    {
        return enemyID.SingleOrDefault(iD => iD.lineAge == lineAge);
    }
}

