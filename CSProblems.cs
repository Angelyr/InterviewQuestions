public class CSProblems{
    
    public int Tribonacci(int n) {
        int t0 = 0;
        int t1 = 1;
        int t2 = 1;
        
        if(n==0) return 0;
        if(n==1 || n==2) return 1;
        
        int t = 3;
        for(int i=3; i <= n; i++){
            t = t0 + t1 + t2;
            t0 = t1;
            t1 = t2;
            t2 = t;
        }
        
        return t;
    }

    public int[] DistributeCandies(int candies, int num_people) {
        int[] result = new int[num_people];
        
        int i=0;
        int myCandies = 1;
        while(candies > 0){
            if(myCandies > candies){
                result[i] += candies;
                break;
            }
            else{
            result[i] += myCandies;
            candies -= myCandies;    
            }
            
            
            myCandies+=1;
            i+=1;
            if(i == num_people) i = 0;
        }
        return result;
    }



    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }


    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if(root.val < val){
            if(root.right == null){
                root.right = new TreeNode(val);
                return root;
            }
            else{
                root.right = InsertIntoBST(root.right, val);
                return root;
            }
        }
        
        if(root.val > val){
            if(root.left == null){
                root.left = new TreeNode(val);
                return root;
            }
            else{
                root.left = InsertIntoBST(root.left, val);
                return root;
            }
        }
        
        return null;
    }
}