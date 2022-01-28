using ClassLibraryBatleShip;
using Microsoft.AspNetCore.Mvc;
using WebBatleShip.Games;
using WebBatleShip.Models;

namespace WebBatleShip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatleShipController : Controller
    {
        private IGame game;

        public BatleShipController(IGame game)
        {
            this.game = game;
        }

        [HttpGet]
        [Route("Shoot1")]
        public MsgToFront Shoot1()
        {
            game.PlayerOneMove();
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        [HttpGet]
        [Route("Shoot2")]
        public MsgToFront Shoot2()
        {
            game.PlayerTwoMove();
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        //BatleShip/23
        [HttpPut("{id:int}")]
        public MsgToFront ManualShoot(int it,BoardPoint boardPoint)
        {
            game.HumanMove(boardPoint.Vertical, boardPoint.Horizontal);
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        //BatleShip/23
        [HttpPost("{id:int}")]
        public MsgToFront ManualShoot2(int it, Department dfs)
        {
            game.PlayerTwoMove();
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }

        //BatleShip/changeplayer
        [HttpPost("changeplayer")]
        public void ChangePlayer([FromBody] bool xxx)
        {
            game.player2 = xxx ? new HumanPlayer(game.boardMaker) : new ComputerPlayer(game.boardMaker);
            System.Console.WriteLine(xxx);
            System.Console.WriteLine("sdf");
            //return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        //BatleShip
        [HttpPost]
        public MsgToFront ManualShoot2([FromBody] string xxx)
        {
            game.PlayerTwoMove();
            string www = xxx;
            System.Console.WriteLine(www);
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        //BatleShip/NewGame
        [HttpGet]
        [Route("NewGame")]
        public MsgToFront NewGame()//(bool player1)
        {
            game.boardMaker = new BoardMaker();
            game.player1 = new ComputerPlayer(game.boardMaker);
            //tutaj wstawic wybor czy ma byc grac human czy computer
            //game.player2 = player1 ? new ComputerPlayer(game.boardMaker) : new HumanPlayer(game.boardMaker);
            game.player2 = new HumanPlayer(game.boardMaker);
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
        [HttpGet]
        public MsgToFront Get()
        {
            return new MsgToFront() { FieldsListPlayer1 = game.player1.PlayerBoard, FieldsListPlayer2 = game.player2.PlayerBoard, IsMyTurn = game.whoWin };
        }
    }
}
