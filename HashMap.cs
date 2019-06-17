using System;

namespace HashKey{
    class HashMap{
        public Data[] Map;

        public int hashFunction (string name){
            int sum = 0;
            /* 
            The Hash is the combination of the Ascii value of the characters of the key
            To decrease collisions the Ascii value of each character is multiplied by its place in the key
            */
            
            for(int i = 0; i<name.Length; i++){
                char character = name[i];
                int weight = (int) character * (i+1);
                sum += weight;
            }
            int index = sum% Map.Length;
            return index;
        }
        public int store (Data newData){
            int index = hashFunction(newData.key);
            if(Map[index] == null){
                Map[index]= newData;
                return index;
            }else{
                //Collision solution
                int collision = linearProbe(newData, index);
                return collision;
            }
        }
        public string retrieve (string key){
            int index = hashFunction(key);

            if(Map[index]==null){
                return "Not in Hash Map";
            }            
            else if(Map[index].key == key){
                return $"{Map[index].content}; found at index: {index}";
            }else{
                string collision = linearRetrive(key,index);
                return collision;
            }
        }
        public string linearRetrive(string key, int index){
            System.Console.WriteLine("Using Linear Probing");
                int probe = index + 1;
                while(probe != index){
                    if(Map[probe].key == key){
                        return $"{Map[probe].content}; found at index: {probe}";
                    }
                    probe++;
                    if(probe == Map.Length){
                        probe = 0;
                    }
                }
                return "Not in Hash Map";
                
        }
        public int linearProbe(Data newData, int index){
            System.Console.WriteLine("Using Linear Probing");
                int probe = index + 1;
                /* The probe starts after the occupied index, then loops to index 0 after hitting the end of the array */
                while(probe != index){
                    if(Map[probe] == null){
                        Map[probe]=newData;
                        return probe;
                    }
                    probe++;
                    if(probe == Map.Length){
                        probe = 0;
                    }
                }
                System.Console.WriteLine("No Space in HashMap");
                return -1;
        }


        public HashMap(){
            Map = new Data[29];
            // Using a Prime number to reduce frequency of collision via modulus
        }
    }
}