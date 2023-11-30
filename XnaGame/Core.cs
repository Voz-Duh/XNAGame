﻿using nkast.Aether.Physics2D.Dynamics;
using System;
using XnaGame.Entities;
using XnaGame.UI.GUIElements;
using XnaGame.Utils;
using XnaGame.Utils.Graphics;
using XnaGame.WorldMap;

namespace XnaGame
{
    public static class Core
    {
        public static Sprite[] icons;
        public static Sprite OnInventoryIcon => icons[1];
        public static Sprite OffInventoryIcon => icons[0];

        public static Button.Style buttonStyle;
        public static Window.Style windowStyle;

        public static DynamicSpriteFontScaled font;

        public static (Action draw, Action update) entities = (() => { }, () => { });
        public static World world;
        public static IMap map;
        public static Camera camera;
        public static Action criticalGuiDraw = () => { };

        public static T GetEntity<T>()
            where T : Entity
        {
            foreach (var entity in entities.update.GetInvocationList())
            {
                if (entity.Target is T t) return t;
            }
            return null;
        }
        public static void AddEntity(Action draw, Action update)
        {
            entities.update += update;
            entities.draw += draw;
        }
        public static void RemoveEntity(Action draw, Action update)
        {
            entities.update -= update;
            entities.draw -= draw;
        }
    }
}