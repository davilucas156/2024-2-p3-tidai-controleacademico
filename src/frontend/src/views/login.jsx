import InputLogin from '../components/common/inputLogin'

const login = () => { 
    return (
        <div className="container flex flex-col bg-gray-200 p-2 gap-4 items-center rounded-lg w-[70%] h-[50%]">
           <div className="aloc-inputs-with-login flex flex-col gap-2 w-[70%]"> 
            <InputLogin />
           <div className="container-has-problem-with-login">
            <p className=" text-xs font-bold underline text-white flex flex-row-reverse hover:text-black">Problems with your account? Click here</p> 
           </div>
           </div>
        </div>
    );
}

export default login;