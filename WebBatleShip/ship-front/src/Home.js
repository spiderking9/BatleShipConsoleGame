import React,{Component} from "react";
import { variables } from "./Variables";

export class Home extends Component{
    constructor(props){
        super(props);
        this.state={
            board:0,
            FieldsList1:[],
            FieldsList2:[],
            break:false,
            isButtonDisabled: false,
            player1human:false,
            howTurn:1
        }
        this.firstOpen = this.firstOpen.bind(this);
        this.newGame = this.newGame.bind(this);
        this.stopGame = this.stopGame.bind(this);
        this.change= this.change.bind(this);
        this.encodeImageFileAsURL= this.encodeImageFileAsURL.bind(this);

    }

    

    firstOpen(){
        fetch(variables.BATLE_SHIP_URL)
        .then(response=>response.json())
        .then(data=>this.setState({FieldsList1:data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn}))
    }
    newGame(isHuman){
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(isHuman)
        };
        fetch(variables.BATLE_SHIP_URL+'NewGame',requestOptions)
        .then(response=>response.json())
        .then(data=>this.setState({FieldsList1:data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn}))
    }
    sleep = (milliseconds) => {
        return new Promise(resolve => setTimeout(resolve, milliseconds))
    }

    
    async shoot(player){
        this.setState({
            isButtonDisabled: false
          });
        await fetch(variables.BATLE_SHIP_URL+'Shoot'+player)
        .then(response=>response.json())
        .then(data=>{

            // for (var key in data) {
            //     if (data.hasOwnProperty(key)) {
            //         console.log(key);
            //     }
            // }
            console.log(data.IsMyTurn + " wielkosc "+ data.FieldsListPlayer2.length)
            console.log()
            if(!data.FieldsListPlayer2){
                if(data.FieldsListPlayer2.length !== 0){
                    this.setState({FieldsList1: data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn})
                }
            }
            else{
                this.setState({FieldsList1: data.FieldsListPlayer1, board:data.IsMyTurn,FieldsList2:data.FieldsListPlayer2})
            }
            //this.setState({FieldsList1: data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn})
        })
        console.log(this.state.board);
        if(!this.state.player1human || this.state.board===0){
            await this.sleep(200).then(async ()=>{
                if(!this.state.break){
                    if(this.state.board<2) await this.shoot(this.state.board+1);
                }
                this.state.break=false;
            })
        }
    }


    async shootHuman(vert,hori){
        const requestOptions = {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ Vertical: vert, Horizontal:hori })
        };
        await fetch(variables.BATLE_SHIP_URL+'23' ,requestOptions)
        .then(response=>response.json())
        .then(data=>this.setState({FieldsList1:data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn}))

        //tutaj sprawdzamy kto ma ruch 
        if(this.state.board===0) 
        {
            this.shoot(1);
        } 
    }

    isBtnDisabled(param) {
        if(this.state.board===0) return true;
        if(!this.state.player1human) return true;
        switch(param) {
            case 0:
            case 1:
                return false;
            default:
                return true;
        }
      }

    colorChoser(param) {
        switch(param) {
            case 1:
                return 'red';
            case 0:
                return 'blue';
            case 2:
                return 'pink';
          default:
            return 'brown';
        }
      }

    colorChoser2(param) {
        switch(param) {
            case 1:
                return 'red';
            case 0:
                return 'blue';
            case 2:
                return 'pink';
            case 3:
                return 'orange';
            case 4:
                return 'purple';
          default:
            return 'brown';
        }
      }
      whoWin(board) {
        if(board===3||board===4)
        { 
            return "Wygrał gracz: " + (board-2);
        }
        else return "-"; 
      }


    componentDidMount(){
        this.firstOpen()
    }

    stopGame(){
        this.setState({break:true});
        this.setState({
            isButtonDisabled: false
          });
    }

    async changePlayerType(isHuman){

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(isHuman)
        };
        fetch(variables.BATLE_SHIP_URL+'changeplayer' ,requestOptions)
        .then(response=>response.json())
        .then(data=>this.setState({FieldsList1:data.FieldsListPlayer1, FieldsList2:data.FieldsListPlayer2, board:data.IsMyTurn}))
    }

    change(event){
        if(event.target.value==='human') {
            this.changePlayerType(true);
            this.setState({player1human:true});
        }
        else 
        {
            this.setState({player1human:false})
            this.changePlayerType(false);
        }
        //console.log(event.target.value+" "+ this.state.player1human)
    }

    encodeImageFileAsURL(element) {
        //console.log(element.value);
        if(element.files===undefined) return;
        var file = element.files[0];
        var reader = new FileReader();
        reader.onloadend = function() {
          //console.log('RESULT', reader.result)
        }
        reader.readAsDataURL(file);
      }
    //   this.setState({
    //     items: update(this.state.items, {1: {name: {$set: 'updated field name'}}})
    //   })

    render(){
        const {
            FieldsList1, FieldsList2, board ,player1human
        }=this.state;
        return(
            <div>
                <h3>This is Home part </h3>
                <select name="player" onChange={this.change}>
                    <option value="computer" >computer</option>
                    <option value="human">human</option>
                </select>
                <div className="wrapper2">
                    <div className="wrapper" style={{opacity:board+1===2?0.5:1}}>
                        {FieldsList1.map(w=>
                        <div style={{background:this.colorChoser(w.FieldStatus)}}>
                            {w.Vertical} {w.Horizontal} {w.FieldStatus}
                        </div>
                        )}
                    </div>
                    <div className="wrapper" style={{opacity:board+1===1?0.5:1}}>
                        {FieldsList2.map(w=>
                        <button onClick={this.shootHuman.bind(this,w.Vertical,w.Horizontal)}
                            style={{background:this.colorChoser(w.FieldStatus)}}
                            disabled={this.isBtnDisabled(w.FieldStatus)}
                            >
                            {w.Vertical} {w.Horizontal} {w.FieldStatus}
                        </button>
                        )}
                    </div>
                </div>
                <button onClick={this.newGame.bind(this,player1human)}>NewGame</button>
                <text style={{background:this.colorChoser2(board), height:200, width:200}}> {this.whoWin(board)} </text>
                <button disabled={this.state.isButtonDisabled} onClick={this.shoot.bind(this,1)}>StartGame</button>
                <button onClick={this.stopGame}>StopGame</button>
                <input type="file" id="ctrl" webkitdirectory multiple  />
                {/* onchange={this.encodeImageFileAsURL(this)} */}
            </div>
        )
    }
}