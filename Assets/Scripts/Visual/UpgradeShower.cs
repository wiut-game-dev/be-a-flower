using TMPro;
using UnityEngine;
using System.Text;
using System.Linq;
using System.Collections.Generic;


public class UpgradeShower : MonoBehaviour
{
	public TMP_Text Stem;
	public TMP_Text Message;
	public TMP_Text NodesFill; //displays nodes overall (the list)
	public TMP_Text AvailableNodes; //for show how many nodes are available to fill

	public UpgradeState upgradeState;
	public GeneralState generalState;

	private void Start()
	{
		//firstly, show all possible upgrades of aspects
		ShowAvailableStem();

		ShowNodesStatus();

	}

	private void Update()
	{
		//when according key is pressed, upgrade aspect
		if(Input.GetKeyUp(KeyCode.S))
		{
			Debug.Log("S up");//for debug purposes
			UpgradeStem();
		}

		if (Input.GetKeyUp(KeyCode.W)) //Nodes update with Leaf
		{
			Debug.Log("W up"); //for debug purposes
			UpgradeNode(Aspect.Leaves);

		}

		if (Input.GetKeyUp(KeyCode.F)) //Nodes update with Flower
		{
			Debug.Log("F up"); //for debug purposes
			UpgradeNode(Aspect.Flowers);
		}
	}

	public void ShowAvailableStem()
	{
		//retrieve next available stem upgrade and show it on textbox
		Upgrade upg = upgradeState.Next(Aspect.Stem);
		Stem.text = $"{upg.Cost}|{upg.Name} - {upg.Description}";
	}

	public void UpgradeStem()
	{
		//try to upgrade stem
		if(upgradeState.UpgradeNext(generalState, Aspect.Stem))
		{
			//if yes, say so and update available upgrade
			ShowAvailableStem();
			Message.text = "Successful update";
		}
		else
		{
			//if no, say so
			Message.text = "Can not upgrade";
		}
	}

	//Node Upgrades:

	public void ShowNodesStatus()
	{
		//shows available nodes that can be filled 
		int availableCount = generalState.Nodes.Count(node => node == NodeType.Empty);
		AvailableNodes.text = $"Available Nodes: {availableCount}";

		//shows what nodes are filled with

		StringBuilder nodeStatusBuilder = new StringBuilder();
		nodeStatusBuilder.Append("Node Status: ");

		if (generalState.Nodes.Count == 0)
		{
			nodeStatusBuilder.Append("[None]");
		}
		else
		{
			foreach (NodeType nodeType in generalState.Nodes)
			{
				nodeStatusBuilder.Append($"[{nodeType}] ");
			}
		}
		NodesFill.text = nodeStatusBuilder.ToString();
	}

	public void UpgradeNode(Aspect aspect)
	{
		if (upgradeState.UpgradeNext(generalState, aspect))
		{
			Message.text = $"Successful {aspect} upgrade!";
		}
		else
		{
			Message.text = $"Cannot upgrade {aspect}. Check cost or node availability.";
		}

		ShowNodesStatus();
	}

}

